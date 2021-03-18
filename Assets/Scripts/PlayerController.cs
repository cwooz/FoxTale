using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rigidBody;
    
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;                 // Still Needs work, isGrounded is set to TRUE

    private Animator animator;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rigidBody.velocity.y);    //.GetAxisRaw()

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 2f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }


        if (rigidBody.velocity.x < 0)       // Check for Player Movement to the LEFT
        {
            spriteRenderer.flipX = true;    // Change sprite animaton facing
        }
        else if (rigidBody.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }


        animator.SetFloat("moveSpeed", Mathf.Abs(rigidBody.velocity.x));        // Change Animation to Running

        animator.SetBool("isGrounded", isGrounded);     // Not Working: Find out why isGrounded stays TRUE on 1st Jump      // Change Animation to Jumping
    }
}
