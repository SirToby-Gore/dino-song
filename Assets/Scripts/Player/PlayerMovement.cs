using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    public bool isGrounded; // This will be used for the jumping conditions.
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); // Grab the characters body on initialization.
    }

    
    void Update()
    {
        Move();
        JumpInput();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(1*moveSpeed, rb.linearVelocity.y);
    }

    public void Jump() // Removed keyboard input so that logic can be implemented into notes control.
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
        
    }

    void JumpInput() // Using keyboard control for early work.
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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
