using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    public Text countText;
    public Text winText;
    public Text loseText;
    public AudioClip musicClipPickup;
    public AudioClip musicClipBgm;
    public AudioClip musicClipWin;
    public AudioClip musicClipLose;
    public AudioSource musicSource;
    public AudioSource musicSourcePickup;

    private int count;

    public float startingTime;
    public Text theText;

    public float speed;
    public float jumpForce;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        musicSource = GetComponent<AudioSource>();

        count = 0;
        winText.text = "";
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        SetCountText();
        musicSource.clip = musicClipBgm;
        musicSource.Play();
        musicSource.loop = true;
    }

    void Update()
    {
        if (startingTime >= 0)
            startingTime -= Time.deltaTime;
        theText.text = "Time: " + Mathf.Round(startingTime);
        if (startingTime >= 10)
        {
            theText.text = "Time: 10";
        }
        if (startingTime <= 0)
        {
        //    theText.text = "Time: 0";
            SetCountText();
        }
    }

    void FixedUpdate()
    {        
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            {
                if (spriteRenderer != null)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            musicSourcePickup.clip = musicClipPickup;
            musicSourcePickup.Play();

        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (startingTime <= 0 && count >= 4)
        {
            winText.gameObject.SetActive(true);
            winText.text = "You Win!";
            musicSource.Stop();
        }
        if (startingTime <= 0 && count < 4)
        {
            loseText.gameObject.SetActive(true);
            loseText.text = count.ToString() + " of 4 parts collected \n Game Over!";
            Destroy(gameObject, .1f);
            //musicSource.PlayOneShot(musicClipLose, 0.7F);
        }
            
    }
}