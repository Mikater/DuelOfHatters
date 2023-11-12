using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1MP : NetworkBehaviour
{
    public float speed;
    public float timeToDestroy;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("TimeToDestroy", timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            
        }
        Invoke("TimeToDestroy", 0.01f);
    }
    private void TimeToDestroy()
    {
        Destroy(gameObject);
    }
}
