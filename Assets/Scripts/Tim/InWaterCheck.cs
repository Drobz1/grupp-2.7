using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InWaterCheck : MonoBehaviour
{
    //Niljas fixade gravity
    public Rigidbody2D rb;

    //HELA SCRIPTET ?R GJORT AV TIM S SU21B
    //HELA SCRIPTET ?R GJORT AV TIM S SU21B
    //HELA SCRIPTET ?R GJORT AV TIM S SU21B

    private int plasticValue = 25; //v?rde p? plast
    private int JeweleryValue = 200; //v?rde p? jewelery

    PlasticScore PlasticScore; //referens till plasticscore
    JewleryScore JewleryScore; //referens till jeweleryscore
    Player Player; //refernes till spelaren
    public bool canExit = false;
    // Start is called before the first frame update

    public SpriteRenderer ladderNormal;
    public SpriteRenderer ladderWhite;
    public TMP_Text Enterboat;
    public TMP_Text clickE;
    void Start()
    {

        //REFEREnser
        PlasticScore = FindObjectOfType<PlasticScore>();
        JewleryScore = FindObjectOfType<JewleryScore>();
        Player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) //om man trycker S
        {
            Player.rb.constraints = RigidbodyConstraints2D.None; //st?ng av restrains
        }

        if(canExit && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("LoadingScenePP", LoadSceneMode.Single); //loada loadginscreeen
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enterboat")  //om den kolliderar med n?got som har taget enterboat
        {
            if (Player.deathscreenspawned == false) //om man inte h?ller p? att d?
            {
                canExit = true;
                ladderNormal.gameObject.SetActive(false);
                ladderWhite.gameObject.SetActive(true);
                Enterboat.gameObject.SetActive(true);
                clickE.gameObject.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "b?t") //om spelaren (objektet som scriptet sitter p?) kolliderar med b?t
        {
            if (!Player.deathscreenspawned) //om deathscreen inte ?r spawnad ?n
            {
                
                for (int i = 0; i <= PlasticScore.score; i++) //f?r varje plasticscore
                {
                    Player.money += plasticValue; //l?gg till plasticvalue p? spelarens pengar.
                }
                for (int i = 0; i <= JewleryScore.score; i++) //f?r varje jeweleryscore
                {
                    Player.money += JeweleryValue; //l?gg till jeweleryvalue p? spelarens pengar
                }
                PlasticScore.score = 0; //reseta po?ng
                JewleryScore.score = 0; //reseta po?ng
                Player.money -= plasticValue; 
                Player.money -= JeweleryValue;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //medans spelaren ?r p? detta
    {
        
        if (collision.gameObject.tag == "water") //N?r spelaren kolliderar med vatten
        {

            Player.inWater = true;
            Player.rb.gravityScale = 0f;
            Player.movespeed = 80f;
            Player.reversespeed = -80f;
            Player.swimDown = -80f;
            Player.swimUp = 80f;
        }
        else
        {
            Player.inWater = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //N?r spelare L?MNAR ett omr?de
    {
        if(collision.gameObject.tag == "enterboat") //n?r spelaren kolliderar med omr?det d?r man kan kl?ttra upp f?r stegen till b?ten.
        {
            canExit = false; 
            ladderNormal.gameObject.SetActive(true);
            ladderWhite.gameObject.SetActive(false) ;
            clickE.gameObject.SetActive(false);
            Enterboat.gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "water")
        {
            Player.rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Player.inWater = false;
            Player.rb.gravityScale = 1f;
            Player.movespeed = 0f;
            Player.reversespeed = 0f;
            Player.swimDown = 0f;
            Player.swimUp = 0f;
        }
    }
}
