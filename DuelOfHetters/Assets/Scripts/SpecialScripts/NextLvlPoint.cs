using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvlPoint : MonoBehaviour
{
    public GameObject WinWindow;
    private Animator animator;
    private bool actived = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!actived)
        {
            actived = true;
            animator = GetComponent<Animator>();
            animator.SetTrigger("NextLvl");
            Invoke("WindowActive", 1f);
        }
    }

    private void WindowActive()
    {
        WinWindow.SetActive(true);
    }
}
