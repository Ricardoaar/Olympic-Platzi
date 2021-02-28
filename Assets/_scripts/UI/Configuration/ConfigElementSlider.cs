using UnityEngine;
using UnityEngine.UI;

public class ConfigElementSlider : ConfigElementBase
{
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.value = PlayerPrefs.GetFloat(configParameter, 0.9f);
    }
}
