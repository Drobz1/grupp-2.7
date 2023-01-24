using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementReal : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    private float speed;
    private bool isFacingRight = true;


    float maxspeed = 7;
    public Rigidbody2D rb;

    //Floats för movement hastighet 
    public float movespeed = 5;
    public float reversespeed = -5;
    public float swimUp = 5;
    public float swimDown = -5;
    //Floats för movement hastighet

    public const string Right = "right";
    public const string Left = "left";
    public const string Down = "down";
    public const string Up = "up";

    private string buttonpressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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
        else if(buttonpressed == Down)
        {
            rb.AddForce(new Vector2(0f, swimDown));
        }
        else if (buttonpressed == Up)
        {
            rb.AddForce(new Vector2(0,swimUp));
        }

        Flip();
    }

    private void FixedUpdate()
    {

    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void RaknaUtRiktning() //Räknar ut vilket håll den åker mot
    {
        Vector3 facing = rb.rotation * Vector3.forward;
        Vector3 velocity = rb.velocity;

        // returns the absolute minimum angle difference
        float angleDifference = Vector3.Angle(facing, velocity);

        // returns the angle difference relative to a third axis (e.g. straight up)
        float relativeAngleDifference = Vector3.SignedAngle(facing, velocity, Vector3.up);
    }
}
