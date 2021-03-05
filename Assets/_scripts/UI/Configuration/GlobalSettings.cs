using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum Language
{
    Spanish,
    English,
    Chems
}

public enum TxtCategory
{
    H1,
    MediumText,
    SmallText
}

public enum TxtSize
{
    Small,
    Medium,
    Big
}

public delegate void LanguageEvent(Language text);

public delegate void TextSizeEvent(TxtSize txtSize);

[DefaultExecutionOrder(-1000)]
public class GlobalSettings : MonoBehaviour
{
    public static TxtSize CurrentTextSize;
    public static Language GlobalLanguage;
    public static Difficulty CurrentDifficult;

    [SerializeField] private GlobalConfigurationScriptable currentConfiguration;
    [SerializeField] private GlobalConfigurationScriptable defaultSetting;
    [SerializeField] private List<Difficulty> difficulties = new List<Difficulty>();

    private static GlobalSettings _instance;
    public static LanguageEvent OnUpdateLanguage;
    public static TextSizeEvent OnUpdateTextSize;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else Destroy(gameObject);

        LoadCurrentSettings();
    }


    private void UpdateLanguage(Language newLanguage)
    {
        GlobalLanguage = newLanguage;
        currentConfiguration.language = newLanguage;
        OnUpdateLanguage?.Invoke(currentConfiguration.language);
    }

    public void ChooseDifficult(int difficult)
    {
        UpdateDifficult(difficulties[difficult]);
    }

    private void UpdateDifficult(Difficulty difficult)
    {
        CurrentDifficult = difficult;
        currentConfiguration.difficulty = CurrentDifficult;
    }


    public void RestoreDefaultSetting()
    {
        UpdateLanguage(defaultSetting.language);
        ChangeTextSize(defaultSetting.txtSize);
    }

    private void LoadCurrentSettings()
    {
        UpdateLanguage(currentConfiguration.language);
        ChangeTextSize(currentConfiguration.txtSize);
        UpdateDifficult(currentConfiguration.difficulty);
    }


    private void ChangeTextSize(TxtSize txtSize)
    {
        CurrentTextSize = txtSize;
        currentConfiguration.txtSize = txtSize;
        OnUpdateTextSize?.Invoke(txtSize);
    }


    public void ChangeLanguageEnglish()
    {
        UpdateLanguage(Language.English);
    }

    public void ChangeLanguageSpanish()
    {
        UpdateLanguage(Language.Spanish);
    }

    public void ChangeText(int num)
    {
        switch (num)
        {
            case 1:
                ChangeTextSize(TxtSize.Small);
                break;
            case 2:
                ChangeTextSize(TxtSize.Medium);
                break;
            case 3:
                ChangeTextSize(TxtSize.Big);
                break;
            default:
                print("Language not found");
                break;
        }
    }
}