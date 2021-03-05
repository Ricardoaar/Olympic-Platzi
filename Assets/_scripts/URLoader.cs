using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

public class URLoader : MonoBehaviour
{
    [SerializeField] private PlayableDirector videoTimeline;

    [SerializeField] private VideoPlayer videoPlayerClip;

    private void Awake()
    {
        videoPlayerClip.url = System.IO.Path.Combine(Application.streamingAssetsPath, "cinematica_1_sin_audio.mp4");

        StartCoroutine(_enableAudio());
    }

    private IEnumerator _enableAudio()
    {
        yield return new WaitUntil(() => videoPlayerClip.isPrepared);
        videoTimeline.Play();
    }
}