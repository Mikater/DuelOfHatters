using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("Stats")]
    [Header("Run")]
    public float speed;
    public float smoothTime = 0.5f;

    [Header("Jump")]
    public float jumpForce;
    public float jumpTime;
    public float fallMultiplier;
    public float jumpMultiplier;
    private float movingX;
    Vector2 vecGravity;

    bool isJumping;
    float jumpCounter;

    public float hangTime = 0.1f;
    private float hangCounter;

    [Header("Ground")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Running", movingX!=0);

        if (Input.GetKeyDown(KeyCode.Space))
            JumpButtonDown();
        if (Input.GetKeyUp(KeyCode.Space))

            JumpButtonUp();

        // Стрибок після платформи
        if (isGrounded())
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        // висота стрибка
        if (rb.velocity.y>0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5f) {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }
        //падіння
        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity*fallMultiplier*Time.deltaTime;
        }

        Flip();
        animator.SetBool("isGrounded", isGrounded());
    }

    private void FixedUpdate()
    {
        Run();
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
    private void Run()
    {
        float targetX = movingX * speed; // Цільове значення швидкості

        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, targetX, smoothTime), rb.velocity.y);
    }

    public void JumpButtonDown()
    {
        if (hangCounter<=0f) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
        jumpCounter = 0;
    }

    public void JumpButtonUp()
    {
        isJumping = false;
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


    bool isGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
        return colliders.Length > 0;
    }
}
