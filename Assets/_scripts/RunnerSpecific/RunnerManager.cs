using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class RunnerManager : MonoBehaviour
{
    private KeyCode[] keyCodesKeyboard = {
            KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F
    };

    //private KeyCode[] keyCodesGamePad = {
    //        KeyCode.
    //};

    [SerializeField] private float _timeForInput;
    [SerializeField] private GameObject _inputSprite;

    private bool _inputListener = false;
    private GameObject _currentObstacle;
    private bool _recoveryVelocity;
    private bool _killInputSprite;

    [SerializeField] private GameObject _PlayerRunnerController;
    [SerializeField] private GlobalFloat _gameVelocity;
    [SerializeField] private float _initGameVelocity;


    #region Subject Implementation

    private List<IActiveInputObserver> _activeInputObservers;
    private bool _hurt;

    public void AddObserver(IActiveInputObserver observer)
    {
        _activeInputObservers.Add(observer);
    }

    public void RemoveObserver(IActiveInputObserver observer)
    {
        _activeInputObservers.Remove(observer);
    }

    private void NotifyObservers(Obstacle obstacle)
    {
        foreach (IActiveInputObserver observer in _activeInputObservers)
        {
            observer.Notify(obstacle);
        }
    }

    #endregion

    private void Awake()
    {
        _activeInputObservers = new List<IActiveInputObserver>();
        _gameVelocity.vFloat = _initGameVelocity;
    }

    private void Start()
    {
        AddObserver(_PlayerRunnerController.GetComponent<PlayerRunnerController>());
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputListener)
        {
            CheckInput();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            _currentObstacle = collision.gameObject;
            StartCoroutine(LifeCycleOfInput());
        }
    }

    private IEnumerator Timer()
    {
        for (int i = 0; i < _timeForInput; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        _inputListener = false;
    }

    private IEnumerator LifeCycleOfInput()
    {
        //TODO initial animation 
        _inputListener = true;
        _inputSprite.GetComponent<SpriteRenderer>().enabled = true;

        StartSlowMotion(.2f);

        StartCoroutine(Timer());

        yield return new WaitUntil(() => !_inputListener);

        _recoveryVelocity = true;

        //TODO finish animation 
        _inputSprite.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void CheckInput()
    {
        //TODO
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            NotifyObservers(_currentObstacle.GetComponent<Obstacle>());
            _inputListener = false;
            StopCoroutine(Timer());

        }
    }

    public void StartSlowMotion(float minLevel)
    {
        StartCoroutine(SlowMotion(minLevel));

    }

    private IEnumerator SlowMotion(float minLevel)
    {
        float div = _initGameVelocity / minLevel;
        Debug.Log("Init Slow");

        _recoveryVelocity = false;
        for (int i = 0; i < 100; i++)
        {
            if(_gameVelocity.vFloat > _initGameVelocity / div)
            {
                _gameVelocity.vFloat -= 0.005f;
            }
            if (_recoveryVelocity && !_hurt)
            {
                break;
            }
            yield return new WaitForSeconds(0.005f);
        }
        if (_hurt)
        {
            yield return new WaitForSeconds(1.5f);
            _hurt = false;
        }
        else
        {
            yield return new WaitUntil(() => _recoveryVelocity);

        }
        Debug.Log("Recovery");

        for (int i = 0; i < 100; i++)
        {
            if (_gameVelocity.vFloat < _initGameVelocity)
            {
                _gameVelocity.vFloat += 0.005f;
            }

            yield return new WaitForSeconds(0.002f);
        }

    }

    public void HurtPlayer()
    {
        StopCoroutine(Timer());
        _hurt = true;
        _inputListener = false;
        //StartSlowMotion(.35f, true);
    }

}
