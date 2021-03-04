using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TDPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [Header("Audio Clips")]
    [SerializeField] private AudioClip _dieClip;
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Animator _animator;
    [Header("External Components")]
    [SerializeField] private Camera _camera;

    private Vector2 _direction;
    private Vector3 _checkPoint;

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

    public void Die()
    {
        _input.currentActionMap.Disable();
        _animator.SetTrigger("Die");
        AudioSystem.SI.PlaySFX(_dieClip);
    }

    public void Reset()
    {
        _animator.SetTrigger("Reset");
        _input.currentActionMap.Enable();
        Teleport(_checkPoint);
    }

    public void Teleport(Vector3 position)
    {
        transform.position = position;
        _camera.transform.position = new Vector3(position.x, _camera.transform.position.y, -10);
    }

    public void SetCheckPoint(Vector3 position) => _checkPoint = position;
}
