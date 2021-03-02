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

    private GameObject _player;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _animation.Play();
            _player = collider.gameObject;
        }
    }

    public void Teleport()
    {
        _player.transform.position = _pointToTeleport.position;
        _camera.transform.position = new Vector3(
            _pointToTeleport.position.x, _camera.transform.position.y, -10
        );
        _player.GetComponent<TDPlayerController>().SwitchInputs();
        _collider.enabled = false;
    }
}
