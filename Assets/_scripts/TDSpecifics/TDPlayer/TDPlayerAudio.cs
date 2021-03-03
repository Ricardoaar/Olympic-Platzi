using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDPlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private List<AudioClip> _clips;

    private int _nextClip = 0;

    public void Steps()
    {
        _audio.clip = _clips[_nextClip++];
        _audio.Play();

        if (_nextClip >= _clips.Count)
            _nextClip = 0;
    }
}
