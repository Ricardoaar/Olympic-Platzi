using _scripts.UI.Language;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TextSettings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textContainer;
    [SerializeField] private ComplexText text;
    [FormerlySerializedAs("category")] [SerializeField] private TextCategoryConfiguration categoryConfiguration;
    private TxtSize _textSize;

    private void Awake()
    {
        if (text == null && TryGetComponent(typeof(TextMeshProUGUI), out var dummy))
        {
            textContainer = GetComponent<TextMeshProUGUI>();
        }
    }


    private void OnEnable()
    {
        GlobalSettings.OnUpdateLanguage += UpdateLanguage;
        GlobalSettings.OnUpdateTextSize += UpdateTextSize;
    }


    private void OnDisable()
    {
        GlobalSettings.OnUpdateLanguage -= UpdateLanguage;
        GlobalSettings.OnUpdateTextSize -= UpdateTextSize;
    }

    private void UpdateTextSize(TxtSize newTextSize)
    {
        textContainer.fontSize = categoryConfiguration.GetCurrentSize(newTextSize);
    }

    private void UpdateLanguage(Language language)
    {
        textContainer.text = text.MainText.text;
    }
}