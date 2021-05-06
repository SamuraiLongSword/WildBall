using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void OnSceneLoader(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
}
