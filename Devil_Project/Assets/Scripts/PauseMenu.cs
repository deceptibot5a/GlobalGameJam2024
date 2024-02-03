using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseItems;
    [SerializeField] GameObject pauseButton1;
    [SerializeField] GameObject pauseButton2;
    private bool isPaused;

    public void PauseEvent()
    {
        if (isPaused)
        {
            UnactivePause();
        }
        else
        {
            ActivePause();
        }
    }

    public void ActivePause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseItems.SetActive(true);
        pauseButton1.SetActive(false);
        pauseButton2.SetActive(true);
        print("is paused");
    }
    public void UnactivePause()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseItems.SetActive(false);
        pauseButton1.SetActive(true);
        pauseButton2.SetActive(false);
        print("is not paused");
    }
}
