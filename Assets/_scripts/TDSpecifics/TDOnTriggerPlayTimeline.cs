using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TDOnTriggerPlayTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timeline;

    private void OnTriggerEnter2D()
    {
        _timeline.Play();
    }
}
