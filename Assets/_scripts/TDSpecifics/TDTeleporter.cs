using UnityEngine;
using UnityEngine.Playables;

public class TDTeleporter : MonoBehaviour
{
    [Header("External Components")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _pointToTeleport;
    [SerializeField] private PlayableDirector _animation;

    [Header("Internal Components")]
    [SerializeField] private Collider2D _collider;

    private TDPlayerController _player;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _animation.Play();
            _player = collider.GetComponent<TDPlayerController>();
        }
    }

    public void Teleport()
    {
        if (_player != null)
        {
            _player.Teleport(_pointToTeleport.position);
            _player.SetCheckPoint(_pointToTeleport.position);
            _player.SwitchInputs();
            _collider.enabled = false;
        }
    }
}
