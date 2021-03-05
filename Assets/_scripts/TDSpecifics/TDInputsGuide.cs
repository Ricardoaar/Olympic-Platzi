using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TDInputsGuide : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private Image _icon1;
    [SerializeField] private Image _icon2;
    [Header("Icons")]
    [SerializeField] private Sprite _directionalPadIcon;
    [SerializeField] private Sprite _leftStickIcon;
    [SerializeField] private Sprite _keyboardWasd;

    private string _lastInput;
    private float _timer;
    private float _targetTime = 10.0f;

    private void Update()
    {
        ShowInputs();
        if (_targetTime >= _timer)
            _timer += Time.deltaTime;
        else
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ShowInputs();
    }

    private void ShowInputs()
    {
        _lastInput = _input.currentControlScheme;
        switch (_lastInput)
        {
            case "Keyboard":
            {
                _icon1.sprite = _keyboardWasd;
                _icon2.enabled = false;
                break;
            }
            default:
            {
                _icon1.sprite = _directionalPadIcon;
                _icon2.sprite = _leftStickIcon;
                break;
            }
        }
    }
}
