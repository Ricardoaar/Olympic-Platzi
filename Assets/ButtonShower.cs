using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonShower : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private List<GameObject> gamepad = new List<GameObject>();
    [SerializeField] private List<GameObject> keyboard = new List<GameObject>();

    private string _lastInput;
    private float _targetTime = 10.0f;

    private void Update()
    {
        ShowInputs();
    }

    private void OnEnable()
    {
        ShowInputs();
    }

    private void ShowInputs()
    {
        _lastInput = _input.currentControlScheme;
        Debug.Log(_input.currentControlScheme);
        switch (_lastInput)
        {
            case "Keyboard":
            {
                foreach (var but in keyboard)
                {
                    but.SetActive(true);
                }

                foreach (var button in gamepad)
                {
                    button.SetActive(false);
                }

                break;
            }
            default:
            {
                foreach (var but in keyboard)
                {
                    but.SetActive(false);
                }

                foreach (var button in gamepad)
                {
                    button.SetActive(true);
                }

                break;
            }
        }
    }
}