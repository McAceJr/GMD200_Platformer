using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public static bool[] levelComplete = new bool[4];

    private int coins = 0;

    public PlayerSettings settings;
    private Rigidbody2D rb;
    public SpriteRenderer Sprite;
    public Animator anim;
    public Transform groundCheck;
    public TextMeshProUGUI tmpro;
    public PauseMenu Pause;

    private float hor;
    private bool jump;
    private bool moving;

    private void Awake()
    {

        tmpro.text = coins.ToString() + "/3";

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        if (!Pause.paused)
        {
            
            hor = Input.GetAxisRaw("Horizontal");

        }
        

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

        
        if (Input.GetKeyDown(KeyCode.R) && !Pause.paused)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


        if (onGround && onGround.collider.tag == "moveable")
        {

            this.transform.parent = onGround.transform;

        }
        else
        {
            this.transform.parent = null;
        }

        if (Input.GetButtonDown("Jump") && onGround && !Pause.paused)
        {

            Flip();

        }

    }

    private void FixedUpdate()
    {

       

        rb.velocity = new Vector2(hor * settings.moveSpeed, Mathf.Clamp(rb.velocity.y, -settings.fallClamp, settings.fallClamp));

        

        if(jump)
        {

            rb.gravityScale = rb.gravityScale * -1;

            jump = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 7) // the layer wont except any variables
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (other.gameObject.tag == "money")
        {

            coins += settings.coinValue;

            Destroy(other.gameObject);

            tmpro.text = coins.ToString() + "/3";

        }

        if (other.gameObject.tag == "exit")
        {

            int i;

            i = SceneManager.GetActiveScene().buildIndex;

            i = i - 2;

            levelComplete[i] = true;

            SceneManager.LoadScene("Level Select");

        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "level" && Input.GetKeyDown(KeyCode.W))
        {

            other.GetComponent<PortalManager>().Teleport();

        }

    }

    public void Flip()
    {

        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x,
                                                               this.gameObject.transform.localScale.y * -1,
                                                               this.gameObject.transform.localScale.z);

        jump = true;

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(groundCheck.position, groundCheck.localScale);

    }

}
