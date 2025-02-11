using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float hor;
    private bool jump;

    public Transform groundCheck;
    public int moveSpeed;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        hor = Input.GetAxisRaw("Horizontal");

        RaycastHit2D onGround = Physics2D.BoxCast(groundCheck.position, groundCheck.localScale, 0f, -transform.up);

        if (Input.GetButtonDown("Jump") && onGround.collider.tag == "ground")
        {

            jump = true;

            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x,
                                                               this.gameObject.transform.localScale.y * -1,
                                                               this.gameObject.transform.localScale.z);

        }

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(hor * moveSpeed, rb.velocity.y);

        if(jump)
        {

            rb.gravityScale = rb.gravityScale * -1;

            jump = false;

        }

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(groundCheck.position, groundCheck.localScale);

    }

}
