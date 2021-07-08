using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STEPUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(41);
    }

    //Exit or X icon in FinalGame
    public void QuitApplication()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    // X icon
    public void QuitGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }

    //Restart or TryAgain
    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }

    //Continue or Resume
    public void ResumeGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    //Settings or AboutUs
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        SceneManager.LoadScene(38);
    }

    public void AboutUs()
    {
        SceneManager.LoadScene(37);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(40);
    }

    public void Sound()
    {
        SceneManager.LoadScene(39);
    }

    public void SoundBack()
    {
        SceneManager.LoadScene(38);
    }
}
