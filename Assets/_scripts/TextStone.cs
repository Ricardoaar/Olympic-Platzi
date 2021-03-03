using _scripts.UI.Language;
using UnityEngine;

public class TextStone : MonoBehaviour
{
    [SerializeField] private AudioClip voiceText;
    [SerializeField] private ComplexText text;

    private void OnEnable()
    {
        PlatPlayerInteractive.OnStoneEnter += DisplayText;
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnStoneEnter += DisplayText;
    }

    public void DisplayText()
    {
        TextWriter.Instance.WriteText(text.MainText.text, voiceText.length);
        AudioSystem.SI.PlaySFX(voiceText);
    }
}