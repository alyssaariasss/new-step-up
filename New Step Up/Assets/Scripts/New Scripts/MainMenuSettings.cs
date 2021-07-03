using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSettings : MonoBehaviour
{
    public void ReturnMain()
    {
        SceneManager.LoadScene(sceneName: "1 Mainscreen");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "2 L1.1");
    }

    public void Settings()
    {
        SceneManager.LoadScene(sceneName: "Settings");
    }

    public void AboutUs()
    {
        SceneManager.LoadScene(sceneName: "AboutUs");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(sceneName: "HowToPlay");
    }

    public void Sound()
    {
        SceneManager.LoadScene(sceneName: "Sound");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
