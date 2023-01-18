using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

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
    public static int money;

    //TUBE
    public bool tubeEquipped;
    public bool inWater;
    public float maxTube = 15;
    public float tubeRemaining;
    public bool isFilled;
    public float refillValue = 1;

    public bool deathscreenspawned = false;
    PlasticScore PlasticScore;
    public GameObject deathscreenprefab;
    float deathTimer = 99999999;


    public TMP_Text balanceText;
    public TMP_Text stats;
    public Canvas pauseMenu;
    bool pauseMenuActive;

    Tubes Tubes;
    Flippers Flippers;
    Goggles Goggles;
    Refill Refill;

    // Start is called before the first frame update
    void Start()
    {
        Tubes = FindObjectOfType<Tubes>();
        Flippers = FindObjectOfType<Flippers>();
        Goggles = FindObjectOfType<Goggles>();
        Refill = FindObjectOfType<Refill>();

        rb = GetComponent<Rigidbody2D>();
        //Ovanför är movement

        PlasticScore = FindObjectOfType<PlasticScore>();
        maxTube = 15;
        speed = 2;
        tubeRemaining = maxTube;
        dead = false;
    }


    // Update is called once per frame
    void Update()
    {
        balanceText.text = "" + money;
        stats.text = "Tube Level: " + Tubes.tubeLevel + "            " + "TubeRefill Level: " + Refill.refillLevel + "          " + "Flippers Level: " + Flippers.flippersLevel + "         " + "Goggles Level: " + Goggles.goggleLevel;
             
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

    
       deathTimer -= 1 * Time.deltaTime;

        if (deathTimer <= 0)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if(tubeRemaining <= 0)
        {
            PlasticScore.score = 0;
            if(!deathscreenspawned)
            {
                Instantiate(deathscreenprefab, new Vector3(0, 0, 0), Quaternion.identity);
                deathscreenspawned = true;
                deathTimer = 5;
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


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuActive)
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseMenuActive = true;
            }
            else if (pauseMenuActive == true)
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                pauseMenuActive = false;
            }
        }
    }

    public void ContinueGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        pauseMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
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
