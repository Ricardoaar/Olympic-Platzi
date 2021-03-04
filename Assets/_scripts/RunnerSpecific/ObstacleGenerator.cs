using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private float creationRate;
    [SerializeField] private GameObject parentForObstacles;
    //TODO random range
    [SerializeField] private float _obstaclesSpeed;
    [SerializeField] private float _minObstaclesSpeed;
    [SerializeField] private float _maxObstaclesSpeed;
    [SerializeField] private float _limitForYPosition;
    private DifficultyScriptable _currentDifficultyScriptable;

    private void Awake()
    {
        _currentDifficultyScriptable = GameObject.Find("CurrentDifficulty").GetComponent<CurrentDifficulty>().currentDifficultyScriptable;

    }

    private void Start()
    {
        creationRate = _currentDifficultyScriptable.initObstacleCreationRate;
        _minObstaclesSpeed = _currentDifficultyScriptable.minObstacleVel;
        _maxObstaclesSpeed = _currentDifficultyScriptable.maxObstacleVel;

        StartCoroutine(GenerateObstacle());

    }

    public void InitGeneration()
    {
        StartCoroutine(GenerateObstacle());
    }

    private IEnumerator GenerateObstacle()
    {
        while (true)
        {
            CreateObstacle();

            yield return new WaitForSeconds(creationRate);
        }
    }

    private void CreateObstacle()
    {
        GameObject prefab = _obstacles[Random.Range(0, _obstacles.Count)];
        Obstacle tmp = prefab.GetComponent<Obstacle>();

        _obstaclesSpeed = Random.Range(_minObstaclesSpeed, _maxObstaclesSpeed);

        switch (tmp.GetObstacleType())
        {
            case ObstacleType.Jump:

                prefab.transform.position = new Vector3(prefab.transform.position.x,
                                                    Random.Range(tmp.GetMinYPosition(),
                                                    _limitForYPosition), 0);

                break;
            case ObstacleType.Duck:

                prefab.transform.position = new Vector3(prefab.transform.position.x,
                                                            tmp.GetMinYPosition(), 0);

                break;
            default:
                break;
        }

        GameObject instance = Instantiate(prefab,
                                        prefab.transform.position, 
                                        Quaternion.identity,
                                        parentForObstacles.transform);

        instance.GetComponent<Obstacle>().SetSpeed(_obstaclesSpeed);


    }

    public void SetMinObstaclesSpeed(float sp)
    {
        _minObstaclesSpeed = sp;
    }

    public void SetMaxObstaclesSpeed(float sp)
    {
        _maxObstaclesSpeed = sp;
    }

    public void SetCreationRate(float sp)
    {
        creationRate = sp;
    }

    public float GetMinObstaclesSpeed()
    {
        return _minObstaclesSpeed;
    }

    public float GetMaxObstaclesSpeed()
    {
        return _maxObstaclesSpeed;
    }

    public float GetCreationRate()
    {
        return creationRate;
    }
}
