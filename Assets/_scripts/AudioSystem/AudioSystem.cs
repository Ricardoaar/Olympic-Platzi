using UnityEngine;
using UnityEngine.Audio;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem SI;

    [SerializeField, Tooltip("AudioSource para la música de fondo")]
    private AudioSource _bgm;

    [SerializeField, Tooltip("AudioSource para los efectos de sonidos")]
    private AudioSource _sfx;

    [SerializeField, Tooltip("AudioSource para los efectos de sonidos en loop")]
    private AudioSource _sfxLoop;

    [SerializeField, Tooltip("Main AudioMixer")]
    private AudioMixer _mixer;

    private AudioClip _bgmClip;

    void Awake()
    {
        if (SI == null)
            SI = this;
    }

    void Update() => ChangeMusic();

    /// <summary>
    /// Play background music
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBGM(AudioClip clip)
    {
        _bgm.clip = clip;
        _bgm.Play();
    }

    public void StopBGM()
    {
        _bgm.Stop();
    }

    /// <summary>
    /// Play sound effect
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySFX(AudioClip clip) => _sfx.PlayOneShot(clip);

    /// <summary>
    /// Play sound effect looped
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySFXLoop(AudioClip clip)
    {
        _sfxLoop.clip = clip;
        _sfxLoop.Play();
    }

    /// <summary>
    /// Stop sound effect looped
    /// </summary>
    public void StopSFXLoop() => _sfxLoop.Stop();

    public void SetGeneralVolume(float volume)
        => _mixer.SetFloat("GeneralVolume", Util.LinearToLogarithmic(volume));

    public void SetBgmlVolume(float volume)
        => _mixer.SetFloat("BGMVolume", Util.LinearToLogarithmic(volume));

    public void SetSfxVolume(float volume)
        => _mixer.SetFloat("SFXVolume", Util.LinearToLogarithmic(volume));

    public void ChangeMusic()
    {
        float currentVolumen;
        _mixer.GetFloat("BGMVolume", out currentVolumen);
        if (!(currentVolumen <= -80.0f))
            return;
        StartCoroutine(FadeMixerGroup.StartFade(_mixer, "BGMVolume", 3.5f, 0.38f));
        PlayBGM(_bgmClip);
    }
}