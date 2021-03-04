using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private ObstacleGenerator obsGenerator;
    //private RunnerManager runnerManager;

    [SerializeField] private float _valueForObsCreationRate;
    [SerializeField] private float _valueForObsMinVel;
    [SerializeField] private float _valueForObsMaxVel;
    [SerializeField] private float _valueForInputTime;
    [SerializeField] private float _valueForGameVelocity;

    private Difficulty _currentDifficulty;

    private void Awake()
    {
        _currentDifficulty = GameObject.Find("CurrentDifficulty").GetComponent<CurrentDifficulty>().currentDifficulty;
        obsGenerator = FindObjectOfType<ObstacleGenerator>();
        //runnerManager= FindObjectOfType<RunnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup / 15 >= 0.9996f && Time.realtimeSinceStartup / 15 <= 1f)
        {
            Debug.Log("IncreaseDifficulty");
            IncreaseDifficulty();
        }

    }

    private void IncreaseDifficulty()
    {
        obsGenerator.SetCreationRate(obsGenerator.GetCreationRate() - _valueForObsCreationRate);
        obsGenerator.SetMaxObstaclesSpeed(obsGenerator.GetMaxObstaclesSpeed() + _valueForObsMaxVel);
        obsGenerator.SetMinObstaclesSpeed(obsGenerator.GetMinObstaclesSpeed() + _valueForObsMinVel);

        DecreaseTimeForInput();

        _currentDifficulty.targetGameVelocity = _currentDifficulty.targetGameVelocity + _valueForGameVelocity;

    }

    private void DecreaseTimeForInput()
    {
        //transform.position = new Vector3(transform.position.x - _valueForInputTime,
        //                                    transform.position.y,
        //                                    transform.position.z);

        GetComponent<Collider2D>().offset = new Vector2(
                                        GetComponent<Collider2D>().offset.x - _valueForInputTime, 
                                        GetComponent<Collider2D>().offset.y);

    }


}
