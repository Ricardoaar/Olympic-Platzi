using UnityEngine;

public enum ObstacleType
{
    JumpHands,
    JumpGhost,
    DuckGhost,
    DuckStaticGhost
}

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType _type;
    [SerializeField] private float _speed;
    private GameObject _referenceKillObstacle;
    private GameObject _referenceCreateObstacle;
    [SerializeField] private float minYPosition;
    [SerializeField] private float _speedCorrection = -1;

    [SerializeField] private GlobalFloat _gameVelocity;
    private Animator _animator;

    private void Awake()
    {
        _referenceCreateObstacle = GameObject.Find("ReferenceCreateObstacle");
        _referenceKillObstacle = GameObject.Find("ReferenceKillObstacle");

        if (GetComponent<Animator>())
        {
            _animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (_animator)
        {
            _animator.SetFloat("GlobalVelocity", _gameVelocity.vFloat + .1f);

        }
    }

    private void FixedUpdate()
    {
        transform.Translate(_speed * Time.deltaTime * _gameVelocity.vFloat * _speedCorrection * -1, 0, 0);
        CheckObstacleLimit();
    }

    private void CheckObstacleLimit()
    {
        if(transform.position.x <= _referenceKillObstacle.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float sp)
    {
        _speed = sp;
    }

    public float GetReferenceCreateObstacle()
    {
        return _referenceCreateObstacle.transform.position.x;
    }

    public ObstacleType GetObstacleType()
    {
        return _type;
    }

    public float GetMinYPosition()
    {
        return minYPosition;
    }
}
