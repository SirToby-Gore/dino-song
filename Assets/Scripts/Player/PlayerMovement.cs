using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isGrounded; // This will be used for the jumping conditions.
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); // Grab the characters body on initialization.
    }

    
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(1*moveSpeed, rb.linearVelocity.y);
    }

    void Jump() // Using keyboard control for early work.
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Added Tag to MainFloor
        {
            isGrounded = true;
        }
    }
}
