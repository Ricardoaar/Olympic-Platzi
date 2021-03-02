using System.Collections;
using UnityEngine;

public class VFXSceneSys : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fadeImg;
    private Coroutine _cFade;

    private void OnEnable()
    {
        PlatPlayerInteractive.OnDamage += OnDamage;
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= OnDamage;
    }

    private void OnDamage()
    {
        StartFadeCoroutine();
    }

    public void StartFadeCoroutine()
    {
        if (_cFade == null)
            _cFade = StartCoroutine(Fading());
        else
        {
            StopCoroutine(_cFade);
            _cFade = StartCoroutine(Fading());
        }
    }

    // ReSharper disable once RedundantDefaultMemberInitializer
    public static bool FadeFinished = false;


    private IEnumerator Fading()
    {
        FadeFinished = false;

        while (fadeImg.color.a < 1)
        {
            fadeImg.color = Util.InterpolateFade(!FadeFinished, fadeImg);
            yield return new WaitForSeconds(0.01f);
        }

        FadeFinished = true;
        yield return new WaitUntil(() => !FadeFinished);
        while (fadeImg.color.a > 0)
        {
            fadeImg.color = Util.InterpolateFade(FadeFinished, fadeImg);
            yield return new WaitForSeconds(0.01f);
        }

        FadeFinished = false;
        _cFade = null;
    }
}