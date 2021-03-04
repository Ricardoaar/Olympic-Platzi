using UnityEngine;

public class SoundEvents : MonoBehaviour
{
    [SerializeField] private AudioClip playerJumpClip, gameOverClip, lvlSfxLoop, ghostDie;

    private void PlayGameOver()
    {
        AudioSystem.SI.PlaySFX(gameOverClip);
        AudioSystem.SI.StopBGM();
    }

    private void PlayGhostDie()
    {
        AudioSystem.SI.PlaySFX(ghostDie);
    }

    private void PlayJump()
    {
        AudioSystem.SI.PlaySFX(playerJumpClip);
    }


    private void Start()
    {
        OnReloadGame();
    }

    private void OnEnable()
    {
        PlatPlayerInteractive.OnDamage += PlayGameOver;
        PlatPlayerInteractive.OnKillEnemy += PlayGhostDie;
        PlayerPlatformInput.OnPlayerJump += PlayJump;
        GameManagePlatform.OnReloadGame += OnReloadGame;
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= PlayGameOver;
        PlatPlayerInteractive.OnKillEnemy -= PlayGhostDie;
        PlayerPlatformInput.OnPlayerJump -= PlayJump;
        GameManagePlatform.OnReloadGame -= OnReloadGame;
    }

    private void OnReloadGame()
    {
        AudioSystem.SI.PlayBGM(lvlSfxLoop);
    }
}