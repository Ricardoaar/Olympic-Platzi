using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TDTrap : MonoBehaviour
{
    [SerializeField] private float _activationTime;
    [SerializeField] private AudioClip _activationClip;
    [Header("Components")]
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayableDirector _timeline;
    [SerializeField] private AudioSource _audio;

    private float _timer;
    private TDPlayerController _player;

    private void Update()
    {
        if (_timer >= _activationTime)
        {
            _animator.SetTrigger("Activate");
            _audio.PlayOneShot(_activationClip);
            _timer = 0.0f;

        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _player = collider.GetComponent<TDPlayerController>();

        if (_player != null)
        {
            _player.Die();
            _timeline.Play();
        }
    }

    public void ResetPlayer() => _player?.Reset();
}
