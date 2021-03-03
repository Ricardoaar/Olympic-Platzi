using UnityEngine;

public enum Language
{
    Spanish,
    English
}

public enum TextSize
{
    Small,
    Medium,
    Big
}


public class GlobalConfiguration : MonoBehaviour
{
    public static TextSize GlobalTextSize;
    public static Language GlobalLanguage;
    [SerializeField] private GlobalConfigurationScriptable currentConfiguration;
    public static GlobalConfiguration Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

        SetGlobalValues(currentConfiguration);
    }

    private void SetGlobalValues(GlobalConfigurationScriptable conf)
    {
        GlobalTextSize = conf.textSize;
        GlobalLanguage = conf.language;
    }
}