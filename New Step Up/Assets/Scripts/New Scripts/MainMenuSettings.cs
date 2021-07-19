using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSettings : MonoBehaviour
{
    public void ReturnMain()
    {
        PlayerPrefs.DeleteKey("Score");
        Invoke("DelayReturnMain", 0.65f);
    }

    private void DelayReturnMain()
    {
        SceneManager.LoadScene(sceneName: "1 Mainscreen");
    }

    public void StartGame()
    {
        Invoke("DelayStartGame", 1f);
    }

    private void DelayStartGame()
    {
        SceneManager.LoadScene(sceneName: "2 L1.1");
    }


    public void Settings()
    {
        Invoke("DelaySettings", 0.7f);
    }

    private void DelaySettings()
    {
        SceneManager.LoadScene(sceneName: "Settings");
    }

    public void AboutUs()
    {
        Invoke("DelayAboutUs", 0.7f);
    }

    private void DelayAboutUs()
    {
        SceneManager.LoadScene(sceneName: "AboutUs");
    }

    public void HowToPlay()
    {
        Invoke("DelayHowToPlay", 0.65f);
    }

    private void DelayHowToPlay()
    {
        SceneManager.LoadScene(sceneName: "HowToPlay");
    }

    public void Sound()
    {
        Invoke("DelaySound", 0.65f);
    }

    private void DelaySound()
    {
        SceneManager.LoadScene(sceneName: "Sound");
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
