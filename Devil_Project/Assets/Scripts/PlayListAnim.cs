using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayListAnim : MonoBehaviour
{
    Animator animator;
    [SerializeField] UiEventManagerScript uiManager;

    bool open = true;
    public bool GetOpen()
    {
        return open;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimButton()
    {
        if (open == true)
        {
            PlayCloseListAnim();
        }
        else
        {
            PlayOpenListAnim();
        }
    }
     void PlayOpenListAnim()
    {
        animator.Play("Lista");
        uiManager.SetListIsOpen(true);
        open = true;
    }

     void PlayCloseListAnim()
    {
        animator.Play("InverseLista");
        uiManager.SetListIsOpen(false);
        open = false;
    }
}
