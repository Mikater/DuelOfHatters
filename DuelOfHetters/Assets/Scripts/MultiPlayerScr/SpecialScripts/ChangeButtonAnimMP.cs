using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonAnimMP : NetworkBehaviour
{
    private bool rotated = false;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimRotate()
    {
        if (rotated)
        {
            rotated = false;
        } else
        {
            rotated = true;
        }
        animator.SetBool("Hook", rotated);
    }
}
