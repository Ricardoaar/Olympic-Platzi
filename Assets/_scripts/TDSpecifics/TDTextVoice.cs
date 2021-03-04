using System.Collections;
using System.Collections.Generic;
using _scripts.UI.Language;
using UnityEngine;

public class TDTextVoice : MonoBehaviour
{
    [SerializeField] private AudioClip voiceText;
    [SerializeField] private ComplexText text;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Trigger();
    }

    public void Trigger()
    {
        TextWriter.Instance.WriteText(text.MainText.text, voiceText.length);
        AudioSystem.SI.PlaySFX(voiceText);
    }
}
