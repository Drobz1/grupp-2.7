using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Scripts/BackButton.cs
    // Start is called before the first frame update
    void Start()
    {

=======

    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;


    float maxspeed = 7;
    public Rigidbody2D rb;

    //Floats f�r movement hastighet 
    public float movespeed = 80;
    public float reversespeed = -80;
    public float swimUp = 80;
    public float swimDown = -80;
    //Floats f�r movement hastighet

    public const string Right = "right";
    public const string Left = "left";
    public const string Down = "down";
    public const string Up = "up";

    private string buttonpressed;
    public float speed = 2;
    public int money;

    public float filledTube = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes:Assets/Player.cs
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream:Assets/Scripts/BackButton.cs

    }

    public void BackStart()
    {
        SceneManager.LoadScene("MainMenu");
=======
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonpressed = Right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            buttonpressed = Left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            buttonpressed = Down;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            buttonpressed = Up;
        }
        else
        {
            buttonpressed = null;
        }



        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);

        if (buttonpressed == Right)
        {
            rb.AddForce(new Vector2(movespeed, 0f));
        }
        else if (buttonpressed == Left)
        {
            rb.AddForce(new Vector2(reversespeed, 0f));
        }
        else if (buttonpressed == Down)
        {
            rb.AddForce(new Vector2(0f, swimDown));
        }
        else if (buttonpressed == Up)
        {
            rb.AddForce(new Vector2(0, swimUp));
        }

        Flip();


        print("filled tube is" + filledTube);
        print("speed is " + speed);
>>>>>>> Stashed changes:Assets/Player.cs
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    /* void RaknaUtRiktning() //R�knar ut vilket h�ll den �ker mot
    {
        Vector3 facing = rb.rotation * Vector3.forward;
        Vector3 velocity = rb.velocity;

        // returns the absolute minimum angle difference
        float angleDifference = Vector3.Angle(facing, velocity);

        // returns the angle difference relative to a third axis (e.g. straight up)
        float relativeAngleDifference = Vector3.SignedAngle(facing, velocity, Vector3.up);
    } */
}
