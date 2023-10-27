using UnityEngine;
using Mirror;

public class PlayerMove : NetworkBehaviour
{
    // Individual Stats
    public float speed = 0.5f;
    public float jumpForce = 10f;
    public int curHealth;
    public int startHealth = 10;

    // Program Stats
    private Rigidbody2D rb;
    private Animator animator;
    public Transform groundCheck;
    public bool canMove = true;
    private float movingX;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isLocalPlayer||!canMove) return;
        if (Input.GetAxis("Horizontal") != 0)
        {   // Рух по горизонталі з клавіатури
            movingX = Input.GetAxis("Horizontal");
        }
        else movingX = 0;

        if (canMove) { // Jump keyboard
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
                rb.AddForce(transform.up * jumpForce * 100);}

        CheckGround(); Run(); Flip();
    }
    private void Flip()
    {
        if (movingX > 0)
        {
            //animator.SetBool("Run", true); // Зміна анімації бігу
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movingX < 0)
        {
            //animator.SetBool("Run", true); // Зміна анімації бігу
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void Run()
    {
        rb.velocity = new Vector2(movingX * speed, rb.velocity.y); // Рух по горизонталі
    }
    // Перевірка наявності землі
    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
    }
}
