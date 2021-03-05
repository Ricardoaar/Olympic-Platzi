using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GlobalConfiguration", menuName = "Configuration/GlobalConfiguration", order = 0)]
public class GlobalConfigurationScriptable : ScriptableObject
{
    public string categoryName;
    public TxtSize txtSize;
    public Language language;
    [FormerlySerializedAs("difficultyScriptable")] [FormerlySerializedAs("Difficulty")] public Difficulty difficulty;
}