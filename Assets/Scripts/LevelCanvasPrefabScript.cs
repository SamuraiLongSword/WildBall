using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCanvasPrefabScript : MonoBehaviour
{
    private bool _isPaused;

    private void Awake()
    {
        GameObject CanvasTextPrefabGO = GameObject.Find("LevelText");

        if(CanvasTextPrefabGO != null)
        {
            Text CanvasTextPrefab = CanvasTextPrefabGO.GetComponent<Text>();
            CanvasTextPrefab.text = "level " + SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void OnGoToMenuMethod()
    {
        OnPausedMethod();
        SceneManager.LoadScene(0);
    }

    public void OnPausedMethod()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
