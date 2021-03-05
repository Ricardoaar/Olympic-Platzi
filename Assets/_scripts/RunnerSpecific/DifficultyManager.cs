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

    public const float LIMIT_OBS_CREATION_RATE = 4f;
    public const float LIMIT_OBS_MIN_VEL = 5f;
    public const float LIMIT_OBS_MAX_VEL = 6f;
    public const float LIMIT_INPUT_TIME = -2.3f;
    public const float LIMIT_GAME_VELOCITY = 1.5F;

    private Difficulty _currentDifficulty;
    private int _phasesCount = 0;

    private void Awake()
    {
        _currentDifficulty = GlobalSettings.CurrentDifficult;
        obsGenerator = FindObjectOfType<ObstacleGenerator>();
        //runnerManager= FindObjectOfType<RunnerManager>();
    }

    public void InitGame()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("IncreaseDifficulty");
        IncreaseDifficulty();
        StartCoroutine(StartGame());
    }

    private void IncreaseDifficulty()
    {
        if(obsGenerator.GetCreationRate() <= LIMIT_OBS_CREATION_RATE)
        {
            obsGenerator.SetCreationRate(LIMIT_OBS_CREATION_RATE);
        }
        else
        {
            obsGenerator.SetCreationRate(obsGenerator.GetCreationRate() - _valueForObsCreationRate);

        }

        if (obsGenerator.GetMaxObstaclesSpeed() >= LIMIT_OBS_MAX_VEL)
        {
            obsGenerator.SetMaxObstaclesSpeed(LIMIT_OBS_MAX_VEL);
        }
        else
        {
            obsGenerator.SetMaxObstaclesSpeed(obsGenerator.GetMaxObstaclesSpeed() + _valueForObsMaxVel);
        }

        if(obsGenerator.GetMinObstaclesSpeed() >= LIMIT_OBS_MIN_VEL)
        {
            obsGenerator.SetMinObstaclesSpeed(LIMIT_OBS_MIN_VEL);
        }
        else
        {
            obsGenerator.SetMinObstaclesSpeed(obsGenerator.GetMinObstaclesSpeed() + _valueForObsMinVel);
        }


        if (GetComponent<BoxCollider2D>().offset.x <= LIMIT_INPUT_TIME)
        {
            GetComponent<BoxCollider2D>().offset = new Vector2(
                                            LIMIT_INPUT_TIME,
                                            GetComponent<BoxCollider2D>().offset.y);
        }
        else
        {
            DecreaseTimeForInput();
        }
        if (_currentDifficulty.targetGameVelocity >= LIMIT_GAME_VELOCITY)
        {
            _currentDifficulty.targetGameVelocity = LIMIT_GAME_VELOCITY;
        }
        else
        {
            _currentDifficulty.targetGameVelocity += _valueForGameVelocity;
        }

        _phasesCount++;
        if(_phasesCount == 10)
        {
            _currentDifficulty.limitForButtons++;
        }
    }

    private void ResetToLimit()
    {

    }

    private void DecreaseTimeForInput()
    {
        GetComponent<BoxCollider2D>().offset = new Vector2(
                                        GetComponent<BoxCollider2D>().offset.x - _valueForInputTime, 
                                        GetComponent<BoxCollider2D>().offset.y);
    }
}
