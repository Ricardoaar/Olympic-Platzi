using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public static void LoadSceneStatic(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}