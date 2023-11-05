using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float speed = 20f;
    public float distance = 5f;
    private Rigidbody2D rb;
    private DistanceJoint2D dist;
    private Animator animator;
    public GameObject catchedObj;
    public bool readyToCatch = true;
    public LayerMask layerToCatch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        dist.distance = distance;
        readyToCatch = true;
    }

    private void Update()
    {
        if (rb.velocity.x < speed)
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!readyToCatch) return;
        if (collision.gameObject.layer == layerToCatch)
        {
            catchedObj = collision.gameObject;
            Catching();
        }
    }

    public void Catching()
    {
        animator.SetTrigger("Catch");
        catchedObj.transform.SetParent(transform);
        readyToCatch = false;
        rb.gravityScale = 1f;
    }

    public void UnCatch()
    {
        catchedObj.transform.SetParent(null);
        animator.SetTrigger("Uncatch");
    }
}
