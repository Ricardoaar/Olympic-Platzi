using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostBehavior : DieOnAnimationFinishComponent
{
    public enum GhostType
    {
        Dark = 1,
        White = 2
    }

    private GameObject _player;

    [SerializeField] private Animator ghostAnimator;
    [SerializeField] private SpriteRenderer ownSprite;
    [SerializeField] private Collider2D ghostCollider;
    private static readonly int AnimatorIsAlive = Animator.StringToHash("isAlive");
    public GhostSpawnSystem ghostSpawnSystem;


    private GhostType _ghostType;
    public GhostType GetGhostType => _ghostType;

    [SerializeField] private float velocity, minWaitTime, maxWaitTime;
    private float _initialVelocity;

    private void Awake()
    {
        if (_player == null)
        {
            _player = GameObject.Find("Player");
        }

        _initialVelocity = velocity;
        ghostSpawnSystem = transform.GetComponentInParent<GhostSpawnSystem>();
    }


    private void ChangeRotation(Vector3 lookAt)
    {
        var rotateY = transform.position.x > lookAt.x;

        float yRotation = rotateY ? 0 : 180;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation,
            Util.GetAngleFromTwoVectors(transform.position, rotateY ? -lookAt : lookAt));
    }

    [SerializeField] private Vector2 offsetPlayer;


    private IEnumerator PrepareAttack()
    {
        var waitTime = Random.Range(minWaitTime, maxWaitTime);
        float currentTime = 0;
        while (currentTime < waitTime)
        {
            ChangeRotation(_player.transform.position);
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(DoAttack());
    }


    private IEnumerator DoAttack()
    {
        var goRight = _player.transform.position.x > transform.position.x;

        Vector3 offset = goRight ? (Vector3) offsetPlayer : new Vector3(-offsetPlayer.x, offsetPlayer.y);

        transform.SetParent(null);
        var currentCount = 0.0f;
        //State 1
        while (Math.Abs(transform.position.x - _player.transform.position.x) > offsetPlayer.x - 0.1f ||
               Math.Abs(transform.position.y - _player.transform.position.y) > Mathf.Abs(offsetPlayer.y) - 0.1f)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                    _player.transform.position + offset,
                    velocity * Time.deltaTime);
            if (goRight && transform.position.x > _player.transform.position.x ||
                !goRight && transform.position.x < _player.transform.position.x)
            {
                break;
            }

            ChangeRotation(_player.transform.position);

            if (currentCount > 2.0f)
            {
                velocity += 1;
                currentCount = 0;
            }
            else
                currentCount += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(SimulateMove(goRight));
    }

    private IEnumerator SimulateMove(bool goRight)
    {
        var currentCount = 0.0;
        while (currentCount < 1.0f)
        {
            transform.position += new Vector3(goRight ? velocity * Time.deltaTime : -velocity * Time.deltaTime,
                -1.0f * Time.deltaTime);
            currentCount += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(GoToOtherSide(goRight));
    }

    private IEnumerator GoToOtherSide(bool goRight)
    {
        var newPos = GhostSpawnSystem.Instance.GetRandomPos(goRight);
        while (Math.Abs(transform.position.x - newPos.x) > 0.2f)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, newPos, velocity * Time.deltaTime);

            ChangeRotation(newPos);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        ghostCollider.enabled = false;
        ghostAnimator.SetBool(AnimatorIsAlive, false);
        var randomPos
            = GhostSpawnSystem.Instance.GetRandomPos(_player.transform.position.x > transform.position.x);
        while (!canDead)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(randomPos.x, -5f), velocity * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        OnDamagePlayer();
    }

    public void Die()
    {
        StopAllCoroutines();
        StartCoroutine(DieCoroutine());
    }


    private void OnEnable()
    {
        SetValues();
        StopAllCoroutines();
        StartCoroutine(PrepareAttack());
        PlatPlayerInteractive.OnDamage += Die;
        PlatPlayerInteractive.OnDamage += OnDamagePlayer;
        GameManagePlatform.OnWinScene += Die;
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= Die;
        PlatPlayerInteractive.OnDamage -= OnDamagePlayer;
        GameManagePlatform.OnWinScene -= Die;
    }

    private void OnDamagePlayer()
    {
        ghostSpawnSystem.OnGhostDisable(gameObject);
    }


    private void SetValues()
    {
        ghostCollider.enabled = true;
        ghostAnimator.SetBool(AnimatorIsAlive, true);
        canDead = false;

        if (GlobalSettings.CurrentDifficult.difficult == Difficult.easy)
            _ghostType = transform.position.x > _player.transform.position.x ? GhostType.White : GhostType.Dark;
        else
            _ghostType = Random.Range(0, 1.0f) > 0.5f ? GhostType.Dark : GhostType.White;


        ownSprite.color = _ghostType == GhostType.Dark ? Color.black : Color.white;

        velocity = _initialVelocity;
    }
}


public abstract class DieOnAnimationFinishComponent : MonoBehaviour
{
    [HideInInspector] public bool canDead;
}