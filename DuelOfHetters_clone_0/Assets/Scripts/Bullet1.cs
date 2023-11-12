using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    private Rigidbody2D rb;

    private Vector3 LastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("TimeToDestroy", timeToDestroy);
    }

    private void Update()
    {
        LastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Reflector"))
        {
            var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * speed;
            return;
        }
        Invoke("TimeToDestroy", 0.01f);
    }
    private void TimeToDestroy()
    {
        Destroy(gameObject);
    }
}
