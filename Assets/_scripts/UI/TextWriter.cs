using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _scripts.UI.Language;
using TMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float timeBetweenWord;
    [SerializeField] private TextMeshProUGUI textContainer;
    public static TextWriter Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void WriteText(string text, float duration = 0)
    {
        if (textContainer.gameObject.activeSelf) return;


        textContainer.gameObject.SetActive(true);
        StartCoroutine(WriteTextCoroutine(text, duration));
    }

    public void WriteText(List<TextScriptable> texts, float duration = 0)
    {
        TextScriptable currentLanguageText =
            texts.FirstOrDefault(txt => txt.textLanguage == GlobalConfiguration.GlobalLanguage);

        if (textContainer.gameObject.activeSelf) return;
        textContainer.gameObject.SetActive(true);

        if (!(currentLanguageText is null)) StartCoroutine(WriteTextCoroutine(currentLanguageText.text, duration));
    }

    public void WriteText(ComplexText text, float duration = 0)
    {
        if (textContainer.gameObject.activeSelf) return;
        textContainer.gameObject.SetActive(true);
        StartCoroutine(WriteTextCoroutine(text.MainText.text, duration));
    }

    private IEnumerator WriteTextCoroutine(string text, float secondsDuration = 0)
    {
        secondsDuration = secondsDuration == 0 ? timeBetweenWord : secondsDuration / text.Length;

        var currentText = "";

        textContainer.text = currentText;

        textContainer.color = new Color(textContainer.color.r, textContainer.color.g, textContainer.color.b, 0);


        for (var index = 0; index <= text.Length; index++)
        {
            currentText = text.Substring(0, index);
            textContainer.color = Util.InterpolateFade(true, textContainer, 0.1f);
            textContainer.text = currentText;
            yield return new WaitForSeconds(secondsDuration);
        }


        while (textContainer.color.a > 0)
        {
            textContainer.color = Util.InterpolateFade(false, textContainer, 0.05f);
            yield return new WaitForEndOfFrame();
        }

        textContainer.gameObject.SetActive(false);
    }
}