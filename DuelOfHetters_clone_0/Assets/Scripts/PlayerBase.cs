using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    public bool lookRight;
    private float movingX;
    public bool moving;

    public Transform groundCheck;

    private Rigidbody2D rb;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Running", movingX!=0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Стрибок
            Jump();
        CheckGround(); Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movingX * speed, rb.velocity.y); // Рух по горизонталі
    }

    public void ButtonRight()
    {
        movingX = 1;
    }
    public void ButtonLeft()
    {
        movingX = -1;
    }
    public void ButtonUp()
    {
        movingX = 0;
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce * 100);
    }

    private void Flip()
    {
        if (movingX > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movingX < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
        animator.SetBool("isGrounded", isGrounded);
    }
}
