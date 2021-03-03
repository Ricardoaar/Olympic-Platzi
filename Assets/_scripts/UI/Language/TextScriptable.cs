using UnityEngine;

[CreateAssetMenu(fileName = "Text", menuName = "Text/Text", order = 0)]
public class TextScriptable : ScriptableObject
{
    public Language textLanguage;
    [TextArea(1, 5)] public string text;
}