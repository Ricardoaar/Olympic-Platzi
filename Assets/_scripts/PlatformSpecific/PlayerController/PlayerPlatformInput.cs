using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Vector2Event(Vector2 vector);

public delegate void GenericEvent();

public class PlayerPlatformInput : MonoBehaviour
{
    #region Declarations

    public static Vector2Event OnPlayerMove;
    public static GenericEvent OnPlayerJump;


    [Header("Components")] [SerializeField]
    private Rigidbody2D playerRb;

    [SerializeField] private BoxCollider2D playerCollider;

    [SerializeField] private RayLayerChecker rayLayerChecker;
    private PlatPlayerController _controller;
    private Collider2D _ladderCollider;

    [Header("Move Variables")] [SerializeField, Range(1, 20)]
    private float moveVelocity;

    [SerializeField, Range(1, 20)] private float jumpForce;

    private Vector2 _direction;
    private bool _climbing;
    private bool _inLadder;
    private Coroutine _cCheckLadder;
    private bool _cancelingAction;

    #endregion

    #region UnityEvents

    private void Awake()
    {
        try
        {
            playerRb = playerRb == null ? GetComponent<Rigidbody2D>() : playerRb;
            playerCollider = playerCollider == null ? GetComponent<BoxCollider2D>() : playerCollider;

            if (playerRb == null || playerCollider == null)
            {
                throw new Exception("Component not found");
            }
        }
        catch (Exception e)
        {
            Debug.Log($"Exception caught: {e} \nAttach Components to {gameObject.name}!");
        }

        ControllerAssign();
    }

    private void OnReloadGame()
    {
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        _controller.Enable();
    }


    private void OnDamage()
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        _controller.Disable();
    }


    private void Update()
    {
        if (_inLadder)
        {
            LadderClimb();
        }
    }

    private void FixedUpdate()
    {
        //   if (playerRb.velocity == Vector2.zero) return;

        if (_climbing)
        {
            playerRb.velocity = moveVelocity * _direction / 2;
        }
        else if (playerRb.bodyType == RigidbodyType2D.Dynamic && CanDash)
        {
            playerRb.velocity =
                new Vector2(_direction.x * moveVelocity, playerRb.velocity.y);
        }

        OnPlayerMove.Invoke(playerRb.velocity);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Ladder")) return;
        _inLadder = false;
        ExitLadder();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Ladder")) return;
        _inLadder = true;
        _ladderCollider = other;
    }


    private void OnEnable()
    {
        CanDash = true;
        GameManagePlatform.OnReloadGame += OnReloadGame;
        PlatPlayerInteractive.OnDamage += OnDamage;
        _controller.Enable();
    }

    private void OnDisable()
    {
        GameManagePlatform.OnReloadGame -= OnReloadGame;
        PlatPlayerInteractive.OnDamage -= OnDamage;
        _controller.Disable();
    }

    #endregion

    #region PlayerBehavior

    private void ControllerAssign()
    {
        _controller = new PlatPlayerController();
        _controller.Main.Movement.performed += ctx => _direction = ctx.ReadValue<Vector2>();
        _controller.Main.Movement.canceled += ctx => _direction = Vector2.zero;
        _controller.Main.Jump.performed += ctx => Jump();
        _controller.Main.CancelAction.performed += ctx => Dash();
    }

    [SerializeField] private float dashForce;

    private void Dash()
    {
        if (!CanDash || !rayLayerChecker.CheckRayToLayer()) return;

        playerRb.velocity = Vector2.zero;

        playerRb.AddForce(50 * Vector2.right * (transform.rotation == Quaternion.identity ? 1 : -1) * dashForce,
            ForceMode2D.Force);

        CanDash = false;
        OnDash.Invoke();
    }

    public static bool CanDash;
    public static Action OnDash;

    // private IEnumerator ReloadDash()
    // {
    //     yield return new WaitForSeconds(0.8f);
    //     _canDash = true;
    // }


    private void Jump()
    {
        if (!rayLayerChecker.CheckRayToLayer()) return;
        CanDash = true;
        OnPlayerJump?.Invoke();
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
    }

    private void LadderClimb()
    {
        if (transform.position.y >= _ladderCollider.bounds.max.y && _direction.y > 0 ||
            _direction.y == 0 && !_cancelingAction) return;
        //Check just if is not climbing and player want to climb
        if (_direction.y != 0 && !_climbing)
            if (!(transform.position.y < _ladderCollider.bounds.min.y && _direction.y < 0))
            {
                _climbing = true;
                playerCollider.isTrigger = true;
                playerRb.bodyType = RigidbodyType2D.Kinematic;
                if (_cCheckLadder != null) StopCoroutine(_cCheckLadder);
                _cCheckLadder = null;
            }

        //Check if player wants to leave ladder
        if (!_cancelingAction &&
            (!(transform.position.y - _ladderCollider.bounds.min.y < 0.2f) || !(_direction.y < 0) ||
             !_climbing)) return;
        ExitLadder();
    }

    private void ExitLadder()
    {
        if (_cCheckLadder != null) return;

        _inLadder = false;
        _cCheckLadder = StartCoroutine(ExitLadderCheck());
    }

    private IEnumerator ExitLadderCheck()
    {
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        _climbing = false;
        yield return new WaitUntil(() => rayLayerChecker.CheckRayToLayer());
        playerCollider.isTrigger = false;
        _cCheckLadder = null;
    }

    #endregion
}