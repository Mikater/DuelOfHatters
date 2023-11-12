using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook1MP : NetworkBehaviour
{
    public float speed = 20f;
    public float distance = 5f;
    private Rigidbody2D rb;
    private DistanceJoint2D dist;
    private HingeJoint2D hinge;
    private Animator animator;
    public GameObject catchedObj;
    public bool readyToCatch = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dist = GetComponent<DistanceJoint2D>();
        hinge = GetComponent<HingeJoint2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        dist.distance = distance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!readyToCatch) return;
        if (collision.gameObject.CompareTag("Object"))
        {
            catchedObj = collision.gameObject;
            rb.gravityScale = 1;
            Catching();
        }
    }

    public void Catching()
    {
        animator.SetTrigger("Catch");
        //catchedObj.transform.SetParent(transform);
        hinge.enabled = true;
        hinge.connectedBody = catchedObj.GetComponent<Rigidbody2D>();
        readyToCatch = false;
    }
}
