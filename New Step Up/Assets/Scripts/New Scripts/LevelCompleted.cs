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
        Invoke("DelayMoveNext", 0.85f);
    }

    public void DelayMoveNext()
    {
        SceneManager.LoadScene(sceneName: NextLevel);
    }

    public void RestartLevel()
    {
        Invoke("DelayRestartLevel", 1f );
    }

    public void DelayRestartLevel()
    {
        SceneManager.LoadScene(sceneName: RestartScene);
    }

    public void ReturnMain()
    {
        Invoke("DelayReturnMain", 1f);
    }

    public void DelayReturnMain()
    {
        SceneManager.LoadScene(sceneName: MainMenu);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
