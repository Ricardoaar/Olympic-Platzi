using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TDPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private PlayerInput _input;

    private Vector2 _direction;

    private void FixedUpdate()
    {
        _rigidBody.AddForce(_direction * _speed, ForceMode2D.Impulse);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
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
