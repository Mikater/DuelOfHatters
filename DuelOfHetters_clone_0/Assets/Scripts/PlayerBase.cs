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
        if (Input.GetAxis("Horizontal") != 0)  // Рух по горизонталі з клавіатури
            movingX = Input.GetAxis("Horizontal");
        else movingX = 0;

        rb.velocity = new Vector2(movingX * speed, rb.velocity.y); // Рух по горизонталі

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Стрибок
            Jump();
        CheckGround();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce * 100);
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
        animator.SetBool("isGrounded", isGrounded);
    }
}
