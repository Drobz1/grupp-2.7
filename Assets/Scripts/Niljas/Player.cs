using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;


public class Player : MonoBehaviour
{    
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


    public bool dead = false; //Kollar om spelaren "håller på" att dö -- Tim
    public static float speed = 1;
    public static int money;  // pengar ofc -- Tim

    //TUBE || Variabler för andningssystemet -- Tim
    public static bool tubeEquipped;
    public static bool inWater;
    public static float maxTube = 15;
    public static float tubeRemaining;
    public bool isFilled;
    public static float refillValue = 2.5f;
    private int spriteVersion = 0;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;

    //Poängrelaterat -- Tim
    public bool deathscreenspawned = false;
    PlasticScore PlasticScore;
    JewleryScore JewleryScore;  
    public GameObject deathscreenprefab;
    float deathTimer = 99999999;

    //Canvasrelaterat -- Tim
    public TMP_Text balanceText;
    public TMP_Text stats;
    public Canvas pauseMenu;
    bool pauseMenuActive;

    //Upgradesrelaterat -- Tim
    public static int tubeLevel = 0;
    public static int flippersLevel = 0;
    public static int gogglesLevel = 0;
    public static int refillLevel = 0;
    public static int flashlightLevel = 0;

    //Pinacolada
    PinaColada PinaColada;
    float drunkTime = 25;

    // Start is called before the first frame update
    void Start()
    {
        
        //Hittar referenser för allt som behövs -- Tim
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
    }


    // Update is called once per frame
    void Update()
    {
        //Om man har köpt pinacolada så är movements invertade och en timer "drunkTime" börjar räkna ner tills den tar slut -- Tim
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
        if(drunkTime <= 0) //om drunkTime är 0 så är man inte drunk längre -- Tim
        { 
            PinaColada.pinaBought = false;
        }

        balanceText.text = "" + money; //Så man kan se ens pengar på skärmen -- Tim
        stats.text = "Tube Level: " + tubeLevel + "            " + "TubeRefill Level: " + refillLevel + "          " + "Flippers Level: " + flippersLevel + "         " + "Goggles Level: " + gogglesLevel + "         " + "Flashlight Level: " + flashlightLevel; // Så man kan se statistics på skärmen om man klickar escape
        if (!PinaColada.pinaBought) //om man inte har köpt pinacolada, movements som vanligt.  -- Tim
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

        if (deathTimer <= 0) //om deathtimer (deathscreenen) är slut, byt scen -- Tim
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if(tubeRemaining <= 0) //om man inte har luft kvar i tuberna -- Tim
        {
            PlasticScore.score = 0; //reseta score -- Tim
            JewleryScore.score = 0; //reseta score -- Tim
            if (!deathscreenspawned) //Om deathscreenen inte har spawnat än (förhindrar att det spawnas flera deathscreens) -- Tim
            {
                Instantiate(deathscreenprefab, new Vector3(0, 0, 0), Quaternion.identity); //skapa en deathscreen  -- Tim
                deathscreenspawned = true; //Markera att den är spawnad, så den inte kan spawnas igen  -- Tim
                deathTimer = 5; //Deathscreenen varar i 5 sekunder  -- Tim
            }
            
        }


        if(Input.GetKeyDown(KeyCode.Escape)) //Om man klickar ESC  -- Tim
        {
            if (!pauseMenuActive) //om pausemenyn inte redan är aktiv  -- Tim
            {
                
                pauseMenu.gameObject.SetActive(true); //Sätt på pausmenyn  -- Tim
                Time.timeScale = 0; //Realtid sätts till 0, inget kan hända i spelet  -- Tim
                pauseMenuActive = true; //Markera att den är aktiv  -- Tim

            }
            else if (pauseMenuActive == true) //Om den redan är aktiv  -- Tim
            {
                pauseMenu.gameObject.SetActive(false); //Sätt den inaktiv  -- Tim
                Time.timeScale = 1; //Fortsätt tiden som vanligt  -- Tim 
                pauseMenuActive = false;
            }
        }
    }

    //KNAPPAR TILL PAUSMENYN -- Tim
    public void ContinueGame() 
    {
        print("klickade continue");
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        print("klickade exit");
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
