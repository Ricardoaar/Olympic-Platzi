using System;
using System.Collections;
using UnityEngine;

public class GameManagePlatform : MonoBehaviour
{
    public static Action OnReloadGame;

    [SerializeField] private GameObject player;
    private Vector3 _initialPosition;
    private Coroutine _cReloadScene;

    private void Awake()
    {
        _initialPosition = player.transform.position;
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

        player.transform.position = _initialPosition;
        yield return new WaitForSeconds(1.0f);
        OnReloadGame.Invoke();
        VFXSceneSys.FadeFinished = false;
        _cReloadScene = null;
    }
}