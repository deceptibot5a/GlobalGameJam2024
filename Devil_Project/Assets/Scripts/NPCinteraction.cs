using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCinteraction : MonoBehaviour
{
    [SerializeField] UiEventManagerScript uiManager;
    [SerializeField] GameObject canvas;
    [SerializeField] NPC nPC;
    [SerializeField] bool isInterface = false;
    private void Awake()
    {
        nPC = this.GetComponent<NPC>();
    }

    private void Update()
    {
        if (canvas.activeInHierarchy == true)
        {
            isInterface = true;
        }
        else
        {
            isInterface =false;
        }
    }
    void OnMouseDown()
    {
        if (!isInterface)
        {
            Debug.Log("Object Clicked!");
            canvas.SetActive(true);

            uiManager.setCharacter(nPC.GetCharacter());
            Time.timeScale = .5f;
        }
        
    }
}
