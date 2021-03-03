using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TDPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Animator _animator;

    private Vector2 _direction;

    private void FixedUpdate()
    {
        _rigidBody.AddForce(_direction * _speed, ForceMode2D.Impulse);

        // Check if object has stopped
        if (_rigidBody.velocity.sqrMagnitude < 0.000995f)
            _animator.SetBool("Walking", false);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        var direction = ctx.ReadValue<Vector2>();

        // Only move on one axis at a time
        if (!(direction.x != 0 && direction.y != 0))
        {
            _direction = direction;
            UpdateAnimation();
        }
    }

    private void UpdateAnimation()
    {
        if (_direction == Vector2.up)
            _animator.SetTrigger("IdleUp");
        else if (_direction == Vector2.down)
            _animator.SetTrigger("IdleDown");
        else if (_direction == Vector2.right)
            _animator.SetTrigger("IdleRight");
        else if (_direction == Vector2.left)
            _animator.SetTrigger("IdleLeft");
        _animator.SetBool("Walking", true);
    }

    public void SwitchInputs()
    {
        switch (_input.currentActionMap.name)
        {
            case "PlayerNormal":
                _input.SwitchCurrentActionMap("PlayerInvented");
                break;
            default:
                _input.SwitchCurrentActionMap("PlayerNormal");
                break;
        }
    }
}
