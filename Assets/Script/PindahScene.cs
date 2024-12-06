using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    public GameObject QuizPanel;
    public GameObject PausePanel;
    public void LoadToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void pause()
    {
        PausePanel.SetActive(true);
    }
    public void resume()
    {
        PausePanel.SetActive(false);
    }
    public void retry(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        PausePanel.SetActive(false);
    }
}
