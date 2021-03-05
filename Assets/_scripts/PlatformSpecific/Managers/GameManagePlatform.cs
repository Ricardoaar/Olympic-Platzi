using System;
using System.Collections;
using UnityEngine;

public class GameManagePlatform : MonoBehaviour
{
    public static Action OnReloadGame;
    public static Action OnWinScene;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform initialPosition;
    private Coroutine _cReloadScene;
    [SerializeField] private GameObject timeLineSceneChange;
    [SerializeField] private GameObject settingMenu;

    private void OnEnable()
    {
        OnWinScene += OnWinSceneManager;
        PlatPlayerInteractive.OnDamage += OnPlayerDamage;
        PlayerPlatformInput.OnPause += OnPause;
    }

    private void OnPause(bool active)
    {
        settingMenu.SetActive(active);
    }

    private void OnWinSceneManager()
    {
        timeLineSceneChange.SetActive(true);
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= OnPlayerDamage;
        PlayerPlatformInput.OnPause -= OnPause;
        OnWinScene -= OnWinSceneManager;
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