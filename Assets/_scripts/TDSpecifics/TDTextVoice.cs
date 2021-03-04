using System.Collections;
using System.Collections.Generic;
using _scripts.UI.Language;
using UnityEngine;

public class TDTextVoice : MonoBehaviour
{
    [SerializeField] private AudioClip voiceText;
    [SerializeField] private ComplexText text;
    [SerializeField] private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Trigger();
        _collider.enabled = false;
    }

    public void Trigger()
    {
        TextWriter.Instance.WriteText(text.MainText.text, voiceText.length);
        AudioSystem.SI.PlaySFX(voiceText);
    }
}
