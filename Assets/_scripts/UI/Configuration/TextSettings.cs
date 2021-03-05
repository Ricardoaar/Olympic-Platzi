using _scripts.UI.Language;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

[DefaultExecutionOrder(1000)]
public class TextSettings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textContainer;
    [SerializeField] private ComplexText text;

    [FormerlySerializedAs("category")] [SerializeField]
    private TextCategoryConfiguration categoryConfiguration;

    private TxtSize _textSize;

    private void Awake()
    {
        if (textContainer == null && TryGetComponent(typeof(TextMeshProUGUI), out var dummy))
        {
            textContainer = GetComponent<TextMeshProUGUI>();
        }
    }


    private void OnEnable()
    {
        if (text != null)
        {
            GlobalSettings.OnUpdateLanguage += UpdateLanguage;
        }

        GlobalSettings.OnUpdateTextSize += UpdateTextSize;
    }


    private void OnDisable()
    {
        if (text != null)
        {
            GlobalSettings.OnUpdateLanguage -= UpdateLanguage;
        }

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