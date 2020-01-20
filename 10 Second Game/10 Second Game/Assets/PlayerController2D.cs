using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    public float speed;
    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        else //make not apply in air after adding ground check
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector2 movement = new Vector2(moveHorizontal, 0);
        //rb2d.AddForce(movement * speed);

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //  rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //}
    }
}
