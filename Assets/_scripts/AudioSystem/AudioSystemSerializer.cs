using UnityEngine;
using UnityEngine.Audio;

public class AudioSystemSerializer : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private void Start()
    {
        _mixer.SetFloat("GeneralVolume",
            Util.LinearToLogarithmic(PlayerPrefs.GetFloat("GeneralVolume", 0.9f))
        );
        _mixer.SetFloat("BGMVolume",
            Util.LinearToLogarithmic(PlayerPrefs.GetFloat("BGMVolume", 0.7f))
        );
        _mixer.SetFloat("SFXVolume",
            Util.LinearToLogarithmic(PlayerPrefs.GetFloat("SFXVolume", 0.8f))
        );
    }

    public void SaveGeneralVolume(float volume)
    {
        PlayerPrefs.SetFloat("GeneralVolume", volume);
        PlayerPrefs.Save();
    }

    public void SaveBgmVolume(float volume)
    {
        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();
    }

    public void SaveSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
}
