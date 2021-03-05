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
    [SerializeField] private float _limitForJumpYPosition;
    [SerializeField] private float _limitForDuckYPosition;
    private Difficulty _currentDifficulty;

    [SerializeField] private bool _generateObstacles = true;

    [SerializeField] private GlobalFloat _gameVelocity;

    private void Awake()
    {

    }

    private void Start()
    {
        _currentDifficulty = GlobalSettings.CurrentDifficult;

    }

    public void InitGame()
    {
        creationRate = _currentDifficulty.initObstacleCreationRate;
        _minObstaclesSpeed = _currentDifficulty.minObstacleVel;
        _maxObstaclesSpeed = _currentDifficulty.maxObstacleVel;
    }

    public void InitGeneration()
    {
        StopAllCoroutines();
        _generateObstacles = true;
        StartCoroutine(GenerateObstacle());
    }

    public void OffGenerateObstacles()
    {
        _generateObstacles = false;
    }

    private IEnumerator GenerateObstacle()
    {
        while (_generateObstacles)
        {
            yield return new WaitForSeconds(creationRate);
            CreateObstacle();

        }
    }

    private void CreateObstacle()
    {
        GameObject prefab = _obstacles[Random.Range(0, _obstacles.Count)];
        Obstacle tmp = prefab.GetComponent<Obstacle>();

        _obstaclesSpeed = Random.Range(_minObstaclesSpeed, _maxObstaclesSpeed);

        switch (tmp.GetObstacleType())
        {            

            case ObstacleType.JumpGhost:

                prefab.transform.position = new Vector3(prefab.transform.position.x,
                                                    Random.Range(tmp.GetMinYPosition(),
                                                    _limitForJumpYPosition), 0);

                break;

            case ObstacleType.JumpHands:

                prefab.transform.position = new Vector3(prefab.transform.position.x,
                                                    tmp.GetMinYPosition(), 0);
                _obstaclesSpeed = 1;
                break;
            case ObstacleType.DuckGhost:

                prefab.transform.position = new Vector3(prefab.transform.position.x,
                                                    Random.Range(tmp.GetMinYPosition(),
                                                    _limitForDuckYPosition), 0);

                break;

            case ObstacleType.DuckStaticGhost:

                prefab.transform.position = new Vector3(prefab.transform.position.x,
                                                    Random.Range(tmp.GetMinYPosition(),
                                                    _limitForDuckYPosition), 0);
                _obstaclesSpeed = 1;

                break;
            default:
                break;
        }

        if (tmp.GetObstacleType() == ObstacleType.DuckGhost || tmp.GetObstacleType() == ObstacleType.JumpGhost)
        {
            Color[] colors = { Color.black, Color.white };
            prefab.GetComponentsInChildren<SpriteRenderer>()[1].color =
                                colors[Random.Range(0, colors.Length)];
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
