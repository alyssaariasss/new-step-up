using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedManager : MonoBehaviour
{
    public void Continue()
    {
        Invoke("DelayContinue", 0.7f);
    }

    public void DelayContinue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    public void Main()
    {
        Invoke("DelayMain", 0.7f);
    }

    public void DelayMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Invoke("DelayRestart", 0.7f);
    }

    public void DelayRestart()
    {
        SceneManager.LoadScene(sceneName: "1");
    }

}
