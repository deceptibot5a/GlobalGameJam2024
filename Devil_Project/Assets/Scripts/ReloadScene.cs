using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    Scene currentScene;
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(currentScene.buildIndex, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void BackToMain()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
    public void Exit()
    {
        Application.Quit();
    }

}
