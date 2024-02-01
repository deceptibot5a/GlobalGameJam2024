using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    } 
}
