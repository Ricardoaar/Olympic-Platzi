using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDBackgroundAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        AudioSystem.SI.PlayBGM(_clip);
    }
}
