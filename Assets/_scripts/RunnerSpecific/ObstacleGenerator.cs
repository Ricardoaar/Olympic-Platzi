using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private float creationRate;
    [SerializeField] private GameObject parentForObstacles;
    [SerializeField] private float _obstaclesSpeed;
    [SerializeField] private float _limitForYPosition;

    private void Start()
    {
        //Asignar variables segun el scriptable object 


        StartCoroutine(GenerateObstacle());

    }

    private void Update()
    {
        //Definir escalabilidad de la dificultad aumentando el _obstacleSpeed
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
}
