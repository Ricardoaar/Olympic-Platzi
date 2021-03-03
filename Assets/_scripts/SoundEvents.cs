using UnityEngine;

public class SoundEvents : MonoBehaviour
{
    [SerializeField] private AudioClip playerJumpClip, gameOverClip, lvlSfxLoop;

    private void PlayGameOver()
    {
        AudioSystem.SI.PlaySFX(gameOverClip);
        AudioSystem.SI.StopBGM();
    }

    private void PlayJump()
    {
        AudioSystem.SI.PlaySFX(playerJumpClip);
    }

    private void OnEnable()
    {
        PlatPlayerInteractive.OnDamage += PlayGameOver;
        PlayerPlatformInput.OnPlayerJump += PlayJump;
        GameManagePlatform.OnReloadGame += OnReloadGame;
    }

    
    
    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= PlayGameOver;
        PlayerPlatformInput.OnPlayerJump -= PlayJump;
        GameManagePlatform.OnReloadGame -= OnReloadGame;
    }

    private void OnReloadGame()
    {
        AudioSystem.SI.PlayBGM(lvlSfxLoop);
    }
}