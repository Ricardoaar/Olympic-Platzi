using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

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

    private bool _inputListener = false;
    private GameObject _currentObstacle;
    private bool _recoveryVelocity;

    [SerializeField] private GameObject _PlayerRunnerController;
    [SerializeField] private GlobalFloat _gameVelocity;

    private Difficulty _currentDifficulty;
    private bool _hurt;
    [SerializeField] private UnityEvent OnWin;

    private bool _buttonA_Fizq;
    private bool _buttonS_Tizq;
    private bool _buttonD_Tder;
    private bool _buttonF_B;
    private int _buttonPressedcount = 0;
    private List<Button> buttons = new List<Button>();
    private int currentButtonsCount = 0;


    #region Subject Implementation

    private List<IActiveInputObserver> _activeInputObservers;
    

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

    private InputActionRunner _input;

    //TODO
    private int _limitForButtons;
    [SerializeField] private GameObject _buttonsContainer;
    [SerializeField] List<GameObject> _buttonsPrefabs;

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Awake()
    {
        _input = new InputActionRunner();
        _input.A_Fizq.Button1.performed += (ctx) => _buttonA_Fizq = true;
        _input.A_Fizq.Button1.canceled += (ctx) => _buttonA_Fizq = false;

        _input.S_Tizq.Button2.performed += (ctx) => _buttonS_Tizq = true;
        _input.S_Tizq.Button2.canceled += (ctx) => _buttonS_Tizq = false;

        _input.D_Tder.Button3.performed += (ctx) => _buttonD_Tder = true;
        _input.D_Tder.Button3.canceled += (ctx) => _buttonD_Tder = false;

        _input.F_B.Button4.performed += (ctx) => _buttonF_B = true;
        _input.F_B.Button4.canceled += (ctx) => _buttonF_B = false;


        //Tres fases performed, darle click
        //no me la se
        //canceled dejar de presionar
        _currentDifficulty = GameObject.Find("CurrentDifficulty").GetComponent<CurrentDifficulty>().currentDifficulty;
        _activeInputObservers = new List<IActiveInputObserver>();

    }

    private void Start()
    {
        AddObserver(_PlayerRunnerController.GetComponent<PlayerRunnerController>());

        _timeForInput = _currentDifficulty.initTimeForInput;
        _gameVelocity.vFloat = _currentDifficulty.initGameVelocity;
        _currentDifficulty.targetGameVelocity = _currentDifficulty.initGameVelocity;
        _limitForButtons = _currentDifficulty.limitForButtons;

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
        }else if (collision.CompareTag("Enemy"))
        {
            if (OnWin != null)
                OnWin.Invoke();

            Debug.Log("HAS GANADO");
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

        GenerateRandomButtons();

        StartSlowMotion(.2f);

        StartCoroutine(Timer());

        yield return new WaitUntil(() => !_inputListener);

        _recoveryVelocity = true;

        //TODO finish animation 
        foreach (Transform item in _buttonsContainer.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }
    }

    private void CheckInput()
    {
        
        for (int i = 0; i < buttons.Count; i++)
        {

            if (buttons[i].type == ButtonType.A_Fizq && _buttonA_Fizq
            || buttons[i].type == ButtonType.D_Tder && _buttonD_Tder
            || buttons[i].type == ButtonType.S_Tizq && _buttonS_Tizq
            || buttons[i].type == ButtonType.F_B && _buttonF_B)
            {
                _buttonPressedcount++;
                ResetButtonsPressed();
                buttons.Remove(buttons[i]);
            }
        }

        if (_buttonPressedcount == currentButtonsCount)
        {
            NotifyObservers(_currentObstacle.GetComponent<Obstacle>());
            _inputListener = false;
            StopCoroutine(Timer());
            _buttonPressedcount = 0;
        }

        //var gamepadButtonPressed = Gamepad.current.allControls.Any(x => x is ButtonControl button && x.IsPressed() && !x.synthetic);
        //if ((Keyboard.current.anyKey.isPressed || gamepadButtonPressed) && _buttonPressedcount == 0)
        //{
        //    Debug.Log("prueba");
        //}

    }

    private void ResetButtonsPressed()
    {
        _buttonA_Fizq = false;
        _buttonS_Tizq = false;
        _buttonD_Tder = false;
        _buttonF_B = false;
    }

    public void StartSlowMotion(float minLevel)
    {
        StartCoroutine(SlowMotion(minLevel));

    }

    private IEnumerator SlowMotion(float minLevel)
    {
        float div = _currentDifficulty.targetGameVelocity / minLevel;

        _recoveryVelocity = false;
        while (_gameVelocity.vFloat > _currentDifficulty.targetGameVelocity / div)
        {
            _gameVelocity.vFloat -= 0.005f;
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

        while (_gameVelocity.vFloat < _currentDifficulty.targetGameVelocity)
        {
            _gameVelocity.vFloat += 0.005f;
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



    private void GenerateRandomButtons()
    {
        int numberOfButtons = Random.Range(1, _limitForButtons);
        numberOfButtons++;

        List<int> listNumbers = new List<int>();
        int number;
        for (int i = 0; i < numberOfButtons; i++)
        {
            do
            {
                number = Random.Range(0, _buttonsPrefabs.Count);
            } while (listNumbers.Contains(number));
            listNumbers.Add(number);
        }

        for (int i = 0; i < numberOfButtons; i++)
        {
            Instantiate(_buttonsPrefabs[listNumbers[i]], _buttonsContainer.transform);
        }
        buttons.AddRange(_buttonsContainer.GetComponentsInChildren<Button>());
        currentButtonsCount = buttons.Count;

    }

}
