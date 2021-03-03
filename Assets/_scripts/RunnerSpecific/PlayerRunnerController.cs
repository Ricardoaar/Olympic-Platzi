using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class PlayerRunnerController : MonoBehaviour, IActiveInputObserver
{
    [SerializeField] private GlobalFloat _gameVelocity;
    private Animator _animator;
    private Rigidbody2D _rb;
    private float _forceToJump;
    [SerializeField] private float _forceForDamage;
    [SerializeField] private float _forceNormalizer;

    [SerializeField] private UnityEvent HurtPlayer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("GlobalVelocity", _gameVelocity.vFloat + .1f);
        _animator.SetFloat("MoveY", transform.position.y);

    }

    public void Notify(Obstacle obstacle)
    {
        StartCoroutine(ActionPlayer(obstacle));
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            HurtPlayer.Invoke();
            Debug.Log("HURT");
        }
    }

    public void Hurt()
    {
        _rb.AddRelativeForce(transform.right * -1 * _forceForDamage, ForceMode2D.Force);
        

    }

    private IEnumerator ActionPlayer(Obstacle obstacle)
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, obstacle.transform.position) < 2f)
            {
                switch (obstacle.GetObstacleType())
                {
                    case ObstacleType.Jump:

                        _animator.SetTrigger("Jump");
                        _forceToJump = obstacle.GetComponent<BoxCollider2D>().bounds.size.y * _forceNormalizer;
                        _rb.AddRelativeForce(transform.up * _forceToJump, ForceMode2D.Impulse);
                        break;
                    case ObstacleType.Duck:

                        _animator.SetTrigger("Duck");

                        break;
                    default:
                        break;
                }
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }

    }
}
