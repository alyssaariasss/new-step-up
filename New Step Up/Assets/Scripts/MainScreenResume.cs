using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenResume : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }
}
