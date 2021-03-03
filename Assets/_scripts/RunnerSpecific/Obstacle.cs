using UnityEngine;

public enum ObstacleType
{
    Jump,
    Duck
}

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType _type;
    [SerializeField] private float _speed;
    private GameObject _referenceKillObstacle;
    private GameObject _referenceCreateObstacle;
    [SerializeField] private float minYPosition;

    [SerializeField] private GlobalFloat _gameVelocity;

    private void Awake()
    {
        _referenceCreateObstacle = GameObject.Find("ReferenceCreateObstacle");
        _referenceKillObstacle = GameObject.Find("ReferenceKillObstacle");
    }

    private void FixedUpdate()
    {
        transform.Translate(-_speed * Time.deltaTime * _gameVelocity.vFloat, 0, 0);
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
