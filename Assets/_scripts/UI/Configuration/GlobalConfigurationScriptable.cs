using UnityEngine;

[CreateAssetMenu(fileName = "GlobalConfiguration", menuName = "Configuration/GlobalConfiguration", order = 0)]
public class GlobalConfigurationScriptable : ScriptableObject
{
    public string categoryName;
    public TextSize textSize;
    public Language language;
}