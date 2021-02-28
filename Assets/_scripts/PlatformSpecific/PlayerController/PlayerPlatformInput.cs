using System;
using System.Collections;
using UnityEngine;

public class PlayerPlatformInput : MonoBehaviour
{
    #region Declarations

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

    private void Update()
    {
        if (_inLadder)
        {
            LadderClimb();
        }
    }

    private void LateUpdate()
    {
        if (_climbing)
        {
            playerRb.velocity = moveVelocity * _direction / 2;


            // (_direction * moveVelocity).sqrMagnitude > moveVelocity

            // ? (_direction * moveVelocity).normalized

            // : _direction * moveVelocity;
        }
        else
        {
            playerRb.velocity =
                new Vector2(_direction.x * moveVelocity, playerRb.velocity.y);
        }
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
        _controller.Enable();
    }

    private void OnDisable()
    {
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
        _controller.Main.CancelAction.performed += ctx => _cancelingAction = true;
        _controller.Main.CancelAction.canceled += ctx => _cancelingAction = false;
    }

    private void Jump()
    {
        if (!rayLayerChecker.CheckRayToLayer()) return;
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