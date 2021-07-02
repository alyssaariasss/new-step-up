using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2CompletedRestart : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "16 2.2");
    }
}