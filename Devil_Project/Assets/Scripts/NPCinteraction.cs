using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCinteraction : MonoBehaviour
{
    [SerializeField] UiEventManagerScript uiManager;
    [SerializeField] GameObject canvas;
    [SerializeField] NPC nPC;
    private void Awake()
    {
        nPC = this.GetComponent<NPC>();
    }
    void OnMouseDown()
    {
        Debug.Log("Object Clicked!");
        canvas.SetActive(true);
        uiManager.setCharacter(nPC.GetCharacter());
        Time.timeScale = .5f;
    }
}
