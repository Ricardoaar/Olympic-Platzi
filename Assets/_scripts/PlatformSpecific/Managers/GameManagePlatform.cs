using System;
using System.Collections;
using UnityEngine;

public class GameManagePlatform : MonoBehaviour
{
    public static Action OnReloadGame;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform initialPosition;
    private Coroutine _cReloadScene;

    private void Start()
    {
        OnReloadGame.Invoke();
    }

    private void OnEnable()
    {
        PlatPlayerInteractive.OnDamage += OnPlayerDamage;
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= OnPlayerDamage;
    }

    public void OnPlayerDamage()
    {
        if (_cReloadScene == null)
            _cReloadScene = StartCoroutine(ReloadScene());
    }


    private IEnumerator ReloadScene()
    {
        yield return new WaitUntil(() => VFXSceneSys.FadeFinished);
        player.transform.position = initialPosition.position;
        yield return new WaitForSeconds(3.5f);
        OnReloadGame.Invoke();
        VFXSceneSys.FadeFinished = false;
        _cReloadScene = null;
    }
}