using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    A_Fizq,
    S_Tizq,
    D_Tder,
    F_B
}

public class Button : MonoBehaviour
{
    public ButtonType type;

    [Tooltip("Posicion 0 debe ser el sprite del keyboard, posicion 1 gamepad")]
    [SerializeField] private List<Sprite> _sprites;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeSpriteToGamePad()
    {
        _image.sprite = _sprites[1];
    }

    public void ChangeSpriteToKeyboard()
    {
        _image.sprite = _sprites[0];
    }

}
