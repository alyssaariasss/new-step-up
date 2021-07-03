using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] private GameObject PauseCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if (isGamePaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene(sceneName: "1 Mainscreen");
    }
}
