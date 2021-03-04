using UnityEngine;
using UnityEngine.Video;

public class OnEndVideo : MonoBehaviour
{
    [SerializeField] private VideoClip clip;

    private void Awake()
    {
        print(clip.length);
        Invoke(nameof(LoadScenesXd), (float) (clip.length + 2));
    }

    private void LoadScenesXd()
    {
        SceneLoader.LoadSceneStatic(2);
    }
}