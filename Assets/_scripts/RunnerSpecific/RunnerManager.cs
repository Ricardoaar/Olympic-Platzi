using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class RunnerManager : MonoBehaviour
{
    private bool _inputListener = false;
    private GameObject _currentObstacle;

    [SerializeField] private GameObject _PlayerRunnerController;
    [SerializeField] private GlobalFloat _gameVelocity;

    private Difficulty _currentDifficulty;
    private bool _hurt;
    [SerializeField] private UnityEvent OnWin;
    [SerializeField] private UnityEvent OnInputListener;

    private bool _buttonA_Fizq;
    private bool _buttonS_Tizq;
    private bool _buttonD_Tder;
    private bool _buttonF_B;
    private int _buttonPressedcount = 0;
    private List<Button> buttons = new List<Button>();
    private int currentButtonsCount = 0;

    [SerializeField] private GameObject _player;
    private float _multiplierDistanceForDestroyInput = 1.66f;

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

    private int _limitForButtons;
    [SerializeField] private GameObject _buttonsContainer;
    [SerializeField] List<GameObject> _buttonsPrefabs;

    [SerializeField] private TextStone _textStone;

    [SerializeField] private ObstacleGenerator obsGenerator;
    [SerializeField] private List<ParallaxBackground> parallaxBackground;

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
        
        _limitForButtons = _currentDifficulty.limitForButtons;

    }

    public void InitGame()
    {
        obsGenerator.InitGeneration();
        foreach (var item in parallaxBackground)
        {
            item.SetInitGame();
        }
        _gameVelocity.vFloat = _currentDifficulty.initGameVelocity;
        _currentDifficulty.targetGameVelocity = _currentDifficulty.initGameVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputListener)
        {
            CheckInput();
            CheckDistanceObstaclePlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            _currentObstacle = collision.gameObject;
            StartCoroutine(LifeCycleOfInput());

            if (OnInputListener != null)
                OnInputListener.Invoke();
        }else if (collision.CompareTag("Enemy"))
        {
            if (OnWin != null)
                OnWin.Invoke();

            Debug.Log("HAS GANADO");
        }
    }

    private IEnumerator LifeCycleOfInput()
    {
        //TODO initial animation 
        _inputListener = true;

        GenerateRandomButtons();

        StartSlowMotion(.2f);

        yield return new WaitUntil(() => !_inputListener);

        //TODO finish animation 
        foreach (Transform item in _buttonsContainer.GetComponentInChildren<Transform>())
        {
            item.GetComponent<Animator>().SetTrigger("ActiveFadeOut");
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
                if(buttons[i])
                    buttons[i].gameObject.GetComponent<Image>().color = Color.green;
                buttons.Remove(buttons[i]);
            }
        }

        if (_buttonPressedcount == currentButtonsCount)
        {
            NotifyObservers(_currentObstacle.GetComponent<Obstacle>());
            ResetParameters();
        }
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

        while (_gameVelocity.vFloat > _currentDifficulty.targetGameVelocity / div)
        {
            _gameVelocity.vFloat -= 0.005f;
            if ((!_inputListener && !_hurt) || _hurt)
            {
                break;
            }
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitUntil(() => !_inputListener);
        if (_hurt)
        {
            _hurt = false;
        }

        while (_gameVelocity.vFloat < _currentDifficulty.targetGameVelocity)
        {
            _gameVelocity.vFloat += 0.005f;
            yield return new WaitForEndOfFrame();
        }
    }

    public void HurtPlayer()
    {
        _hurt = true;
        ResetParameters();
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

    public void ResetParameters()
    {
        _inputListener = false;
        _buttonPressedcount = 0;
        buttons.Clear();
        ResetButtonsPressed();
        if (OnInputListener != null)
            OnInputListener.Invoke();
    }

    private void CheckDistanceObstaclePlayer()
    {
        if (Vector3.Distance(_player.transform.position, _currentObstacle.transform.position)
            <= _currentDifficulty.targetGameVelocity * _multiplierDistanceForDestroyInput)
        {
            ResetParameters();
        }
    }

    public void PlayTextStone()
    {
        _textStone.PlayerTrigger();
    }
}
