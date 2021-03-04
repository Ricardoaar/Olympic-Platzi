using System.Collections;
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
    private int _phasesCount = 0;

    private void Awake()
    {
        _currentDifficulty = GameObject.Find("CurrentDifficulty").GetComponent<CurrentDifficulty>().currentDifficulty;
        obsGenerator = FindObjectOfType<ObstacleGenerator>();
        //runnerManager= FindObjectOfType<RunnerManager>();
    }

    private IEnumerator Start()
    {
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("IncreaseDifficulty");
        IncreaseDifficulty();
        StartCoroutine(Start());
    }

    private void IncreaseDifficulty()
    {
        obsGenerator.SetCreationRate(obsGenerator.GetCreationRate() - _valueForObsCreationRate);
        obsGenerator.SetMaxObstaclesSpeed(obsGenerator.GetMaxObstaclesSpeed() + _valueForObsMaxVel);
        obsGenerator.SetMinObstaclesSpeed(obsGenerator.GetMinObstaclesSpeed() + _valueForObsMinVel);

        DecreaseTimeForInput();

        _currentDifficulty.targetGameVelocity += _valueForGameVelocity;
        _phasesCount++;
        if(_phasesCount == 10)
        {
            _currentDifficulty.limitForButtons++;
        }
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
