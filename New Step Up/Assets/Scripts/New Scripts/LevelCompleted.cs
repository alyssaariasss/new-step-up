using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    [SerializeField]
    private string NextLevel;

    [SerializeField]
    private string RestartScene;

    [SerializeField]
    private string MainMenu;

    public void MoveNext()
    {
        SceneManager.LoadScene(sceneName: NextLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneName: RestartScene);
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene(sceneName: MainMenu);
    }
}
