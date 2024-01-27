using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCinteraction : MonoBehaviour
{

    void OnMouseDown()
    {
        Debug.Log("Object Clicked!");
        SceneManager.LoadScene("DialogueSystemPlayGround", LoadSceneMode.Additive);
    }
}
