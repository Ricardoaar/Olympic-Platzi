using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostBehavior : MonoBehaviour
{
    public enum GhostType
    {
        Dark = 1,
        White = 2
    }

    private GameObject _player;

//    [SerializeField] private Animator ghostAnimator;
    private GhostType _ghostType;
    [SerializeField] private float offsetLookRotationPlayer;

    public GhostType GetGhostType => _ghostType;


    private void Awake()
    {
        if (_player == null)
        {
            _player = GameObject.Find("Player");
        }
    }


    [SerializeField] private float velocity, minWaitTime, maxWaitTime;


    private void ChangeRotation(Vector3 lookAt)
    {
        var rotateY = transform.position.x > lookAt.x;

        float yRotation = rotateY ? 0 : 180;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation,
            Util.GetAngleFromTwoVectors(transform.position, rotateY ? -lookAt : lookAt) + offsetLookRotationPlayer);
    }


    private IEnumerator DoAttack()
    {
        ChangeRotation(_player.transform.position);

        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        var goRight = _player.transform.position.x > transform.position.x;
        while (Math.Abs(transform.position.x - _player.transform.position.x) > 0.2f)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _player.transform.position, velocity * Time.deltaTime);
            ChangeRotation(_player.transform.position);

            yield return new WaitForEndOfFrame();
        }

        var newPos = GhostSpawnSystem.Instance.GetRandomPos(goRight);

        while (Math.Abs(transform.position.x - newPos.x) > 0.2f)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(newPos.x, 6), velocity * Time.deltaTime);

            ChangeRotation(newPos);
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
    }

    public void Die()
    {
        print("I die here");
    }


    private void OnEnable()
    {
        SetRandomValues();
        StartCoroutine(DoAttack());
        PlatPlayerInteractive.OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= OnDamage;
    }

    [SerializeField] private SpriteRenderer ownSprite;

    private void SetRandomValues()
    {
        _ghostType = Random.Range(0, 1.0f) > 0.5f ? GhostType.Dark : GhostType.White;
        ownSprite.color = _ghostType == GhostType.Dark ? Color.black : Color.white;
    }
}