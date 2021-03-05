using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

// ReSharper disable once InconsistentNaming
public class URLoader : MonoBehaviour
{
    [SerializeField] private PlayableDirector videoTimeline;

    [SerializeField] private VideoPlayer videoPlayerClip;

    [SerializeField] private String cinematicName;

    private void Awake()
    {
        videoPlayerClip.url = Path.Combine(Application.streamingAssetsPath, $"{cinematicName}");

        StartCoroutine(ActiveAudio());
    }

    private IEnumerator ActiveAudio()
    {
        yield return new WaitUntil(() => videoPlayerClip.isPrepared);
        videoTimeline.Play();
    }
}