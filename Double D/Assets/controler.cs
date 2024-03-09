using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controler : MonoBehaviour
{

    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 18f;
    private bool isFacingRight = true;

    [SerializeFeild] private Rigidbody2D rb;
    [SerializeFeild] private Transform groundcheck; 
    [SerializeFeild] private LayerMask groundLayer;


     

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5);
        }

        Flip();

    }

    private bool IsGrounded()
    {
        return Physiscs2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
}
