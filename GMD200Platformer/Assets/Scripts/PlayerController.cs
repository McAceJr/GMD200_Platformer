using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    

    public PlayerSettings settings;
    private Rigidbody2D rb;
    public SpriteRenderer Sprite;
    public Animator anim;
    public Transform groundCheck;

    private float hor;
    private bool jump;
    private bool moving;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {

        hor = Input.GetAxisRaw("Horizontal");

        RaycastHit2D onGround = Physics2D.BoxCast(groundCheck.position, groundCheck.localScale, 0f, -transform.up, 0, settings.groundLayer);

        if (hor < 0)
            Sprite.flipX = true;
        else if (hor > 0)
            Sprite.flipX = false;
        
        if (hor != 0)
            moving = true;
        else
            moving = false;
        
        anim.SetBool("moving", moving);



        if (Input.GetButtonDown("Jump") && onGround)
        {

            jump = true;

            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x,
                                                               this.gameObject.transform.localScale.y * -1,
                                                               this.gameObject.transform.localScale.z);

        }

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(hor * settings.moveSpeed, Mathf.Clamp(rb.velocity.y, -settings.clampRange, settings.clampRange));

        

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
