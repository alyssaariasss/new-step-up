using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1CompletedNextLevel : MonoBehaviour { 

    public void PlayGame()
    {
    SceneManager.LoadScene("16 L2.2");
    }
}
