using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float tempMoveSpeed;
    public float jumpForce = 20f;
    public bool isGrounded; // This will be used for the jumping conditions.
    public float direction = 1;
    public float airCount;
    public bool isCrouching;
    public float tempYGravity;
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); // Grab the characters body on initialization.
       isCrouching = false;
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
        else if (airCount > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            airCount --;
        }
        
    }

    public void Crouch()
    {
        if (!isCrouching)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
            isCrouching = true;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
            isCrouching = false;
        }
    }

    // Dashing 
    //  Gravity temporarily 0, so that user moves straight mid air or ground.
    //  MoveSpeed increased then back to previous value.
    //                                              NEEDS COOLDOWN! or a way to not spam the notes.
    public void Dash()
    {
        StartCoroutine(DashDelay(0.5f));
    }

    public IEnumerator DashDelay(float delay)
    {
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        tempYGravity = Physics.gravity.y;
        tempMoveSpeed = moveSpeed;

        Physics.gravity = new Vector3(0, 0, 0);
        moveSpeed = moveSpeed * 3;
        yield return new WaitForSeconds(delay);
        moveSpeed = tempMoveSpeed;
        Physics.gravity = new Vector3(0, tempYGravity, 0);
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
            airCount = 1;
        }
    }
}
