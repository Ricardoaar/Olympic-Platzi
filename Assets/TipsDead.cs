using System.Collections.Generic;
using _scripts.UI.Language;
using UnityEngine;

public class TipsDead : MonoBehaviour
{
    [SerializeField] private List<ComplexText> possibleMainWord = new List<ComplexText>();


    private void OnEnable()
    {
        PlatPlayerInteractive.OnDamage += WriteOnPlayerDamage;
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= WriteOnPlayerDamage;
    }

    private void WriteOnPlayerDamage()
    {
        TextWriter.Instance.WriteText(possibleMainWord[Random.Range(0, possibleMainWord.Count)], 3.5f);
    }
}