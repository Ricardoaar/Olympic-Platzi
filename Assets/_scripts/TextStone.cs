using System.Collections.Generic;
using _scripts.UI.Language;
using UnityEngine;

public class TextStone : MonoBehaviour
{
    [SerializeField] private AudioClip voiceText;
    [SerializeField] private ComplexText text;
    [SerializeField] private List<ExtraAction> actionsOnTrigger;

    private void OnEnable()
    {
        PlatPlayerInteractive.OnStoneEnter += PlayerTrigger;
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnStoneEnter -= PlayerTrigger;
    }

    private void PlayerTrigger()
    {
        TextWriter.Instance.WriteText(text.MainText.text, voiceText.length);
        AudioSystem.SI.PlaySFX(voiceText);
        foreach (var trigger in actionsOnTrigger)
        {
            trigger.DoAction();
        }
    }
}