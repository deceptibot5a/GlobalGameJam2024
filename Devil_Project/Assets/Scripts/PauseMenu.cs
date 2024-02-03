using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseItems;
    [SerializeField] TextMeshProUGUI pauseButtonText;
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
        pauseButtonText.text = "REANUDAR";
        print("is paused");
    }
    public void UnactivePause()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseItems.SetActive(false);
        pauseButtonText.text = "PAUSA";
        print("is not paused");
    }
}
