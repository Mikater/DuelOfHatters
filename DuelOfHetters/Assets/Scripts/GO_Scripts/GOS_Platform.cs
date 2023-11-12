using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOS_Platform : GOS_Base
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("BP", buttonPushed);
    }
}