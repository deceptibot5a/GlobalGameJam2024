using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayListAnim : MonoBehaviour
{
    Animator animator;
    bool open = true;

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
        open = true;
    }

     void PlayCloseListAnim()
    {
        animator.Play("InverseLista");
        open= false;
    }
}
