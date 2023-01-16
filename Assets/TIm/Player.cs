using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;


    float maxspeed = 7;
    public Rigidbody2D rb;

    //Floats för movement hastighet 
    public float movespeed = 80;
    public float reversespeed = -80;
    public float swimUp = 80;
    public float swimDown = -80;
    //Floats för movement hastighet

    public const string Right = "right";
    public const string Left = "left";
    public const string Down = "down";
    public const string Up = "up";

    private string buttonpressed;
    //Ovanför är movement
    //_____________________________________________________:


    public bool dead = false;

    public float speed = 2;
    public int money;

    //TUBE
    public bool tubeEquipped;
    public bool inWater;
    public float maxTube = 15;
    public float tubeRemaining;
    public bool isFilled;
    public float refillValue = 1;

    public bool deathscreenspawned = false;
    DeathScreen DeathScreen;
    public GameObject deathscreenprefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Ovanför är movement

        DeathScreen = FindObjectOfType<DeathScreen>();
        maxTube = 15;
        speed = 2;
        tubeRemaining = maxTube;
        dead = false;
        money = 1000;
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
        else if (buttonpressed == Down)
        {
            rb.AddForce(new Vector2(0f, swimDown));
        }
        else if (buttonpressed == Up)
        {
            rb.AddForce(new Vector2(0, swimUp));
        }

        Flip();
        //Ovanför är movement
        //______________________________

        if (inWater)
        {
            if(tubeEquipped)
            {
                tubeRemaining -= 1 * Time.deltaTime;
            }
            else if (!tubeEquipped)
            {
                tubeRemaining -= 3 * Time.deltaTime;
            }
        }

        else if (!inWater && tubeRemaining != maxTube && tubeRemaining <= maxTube)
        {
            tubeRemaining += refillValue * Time.deltaTime;
        }


        if(tubeRemaining <= 0)
        {
            if(!deathscreenspawned)
            {
                Instantiate(deathscreenprefab, new Vector3(0, 0, 0), Quaternion.identity);
                deathscreenspawned = true;
            }
            



        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            inWater = true;
        }
        if(Input.GetKeyUp(KeyCode.O))
        {
            inWater = false;
        }

        print("filled tube is" + maxTube);
        print("speed is " + speed);
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

    /*void RaknaUtRiktning() //Räknar ut vilket håll den åker mot
    {
        Vector3 facing = rb.rotation * Vector3.forward;
        Vector3 velocity = rb.velocity;

        // returns the absolute minimum angle difference
        float angleDifference = Vector3.Angle(facing, velocity);

        // returns the angle difference relative to a third axis (e.g. straight up)
        float relativeAngleDifference = Vector3.SignedAngle(facing, velocity, Vector3.up);
    } */
}
