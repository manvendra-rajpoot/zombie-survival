using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f, jumpForce = 11f;
    
    private float movementX;

    private SpriteRenderer sr;
    
    private Rigidbody2D myBody;

    private Animator anim;
    private string walk_animation = "walk";

    private bool isGrounded;
    private string ground_tag = "ground";

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementUsingKeyboard();
        AnimatePlayer(); ;
    }

    private void FixedUpdate()
    {
        JumpPlayer();
    }

    void PlayerMovementUsingKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            //right move
            anim.SetBool(walk_animation, true);
            sr.flipX = false;

        } else if (movementX < 0)
        {
            //left move
            anim.SetBool(walk_animation, true);
            sr.flipX = true;

        }
        else
        {
            anim.SetBool(walk_animation, false);
        }
    }

    void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(ground_tag))
        {
            isGrounded = true;
        }
    }

}
