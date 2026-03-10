using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    public bool isGrounded; // This will be used for the jumping conditions.
    public float direction = 1;
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); // Grab the characters body on initialization.
    }

    
    void Update()
    {
        Move();
        JumpInput();
    }

    public void Move()
    {
        rb.linearVelocity = new Vector2(direction*moveSpeed, rb.linearVelocity.y); 
    }

    public void ChangeDirection()
    {
        direction = direction * -1;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
        
    }

    void JumpInput()
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
