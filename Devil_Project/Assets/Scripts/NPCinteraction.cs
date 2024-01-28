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
    [SerializeField] PlayerStats playerStats;
    private void Awake()
    {
        nPC = this.GetComponent<NPC>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        if (canvas.activeInHierarchy == true)
        {
            isInterface = true;
        }
        else
        {
            isInterface = false;
        }
    }
    void OnMouseDown()
    {
        if (!isInterface)
        {

            //Debug.Log("Object Clicked!");
            if (!uiManager.GetListIsOpen())
            {
                canvas.SetActive(true);
                playerStats.interactedNPC = nPC;
                uiManager.SetCharacter(nPC.GetCharacter());
                
            }
            
        }
        
    }
}
