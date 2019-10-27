using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 10.0f;
    public float jumpCoefficient = 20.0f;

    Rigidbody2D rigitbody2D;
    Animator animator;
    Vector2 jumpForce;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigitbody2D = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        jumpForce = Vector3.up * (jumpPower * jumpCoefficient * rigitbody2D.mass * rigitbody2D.gravityScale);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rigitbody2D.AddForce(jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            animator.SetBool("isGrounded", true);
            isGrounded = true;
        }
        if (other.collider.tag == "Enemy")
        {
            animator.SetTrigger("Dead");
            //Destroy(rigitbody2D);
            GameManager manager = FindObjectOfType<GameManager>();
            Debug.Assert(manager != null);
            manager.GameOver();
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            animator.SetBool("isGrounded", true);
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            animator.SetBool("isGrounded", false);
            isGrounded = false;
        }
    }
}
