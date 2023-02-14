using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;

    [SerializeField] PostProcessProfile profile;
    public LensDistortion LensDistortion;
    
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
    //_____________________________________________________


    public bool dead = false;

    public static float speed = 1;
    public static int money;

    //TUBE
    public static bool tubeEquipped;
    public static bool inWater;
    public static float maxTube = 15;
    public static float tubeRemaining;
    public bool isFilled;
    public static float refillValue = 2;
    private int spriteVersion = 0;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;

    public bool deathscreenspawned = false;
    PlasticScore PlasticScore;
    JewleryScore JewleryScore;  
    public GameObject deathscreenprefab;
    float deathTimer = 99999999;


    public TMP_Text balanceText;
    public TMP_Text stats;
    public Canvas pauseMenu;
    bool pauseMenuActive;

    public static int tubeLevel = 0;
    public static int flippersLevel = 0;
    public static int gogglesLevel = 0;
    public static int refillLevel = 0;
    public static int flashlightLevel = 0;


    PinaColada PinaColada;
    float drunkTime = 25;
    // Start is called before the first frame update
    void Start()
    {
        PinaColada = FindObjectOfType<PinaColada>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        //Ovanför är movement

        PlasticScore = FindObjectOfType<PlasticScore>();
        JewleryScore = FindObjectOfType<JewleryScore>();
        maxTube = 15;
        
        tubeRemaining = maxTube;
        dead = false;

        spriteR.flipX = true;

        LensDistortion = FindObjectOfType<LensDistortion>();

        

    }


    // Update is called once per frame
    void Update()
    {

        if(PinaColada.pinaBought)
        {
            drunkTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.AddForce(new Vector2(reversespeed *= speed, 0f));
                
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rb.AddForce(new Vector2(movespeed *= speed, 0f));
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector2(0f, swimUp *= speed));
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector2(0f, swimDown *= speed));
            }
        }
        if(drunkTime <= 0)
        {
            PinaColada.pinaBought = false;
        }

        balanceText.text = "" + money;
        stats.text = "Tube Level: " + tubeLevel + "            " + "TubeRefill Level: " + refillLevel + "          " + "Flippers Level: " + flippersLevel + "         " + "Goggles Level: " + gogglesLevel;
        if (!PinaColada.pinaBought)
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
        }
       

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);

        if (buttonpressed == Right)
        {
            rb.AddForce(new Vector2(movespeed *= speed, 0f));
        }
        else if (buttonpressed == Left)
        {
            rb.AddForce(new Vector2(reversespeed *= speed, 0f));
        }
        else if (buttonpressed == Down)
        {
            rb.AddForce(new Vector2(0f, swimDown *= speed));
        }
        else if (buttonpressed == Up)
        {
            rb.AddForce(new Vector2(0f, swimUp *= speed));
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
            JewleryScore.score = 0;
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

    public void leavePellesPalmer()
    {
        SceneManager.LoadScene("LoadingSceneRight", LoadSceneMode.Single);
    }


    private void Flip()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteR.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteR.flipX = false;
        }
    }
}
