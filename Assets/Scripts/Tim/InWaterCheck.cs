using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InWaterCheck : MonoBehaviour
{
    //Niljas fixade gravity
    public Rigidbody2D rb;

    private int plasticValue = 25; //värde på plast
    private int JeweleryValue = 200; //värde på jewelery

    PlasticScore PlasticScore; //referens till plasticscore
    JewleryScore JewleryScore; //referens till jeweleryscore
    Player Player; //refernes till spelaren
    public bool canExit = false;
    // Start is called before the first frame update
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
            Player.rb.constraints = RigidbodyConstraints2D.None; //stäng av restrains
        }

        if(canExit && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("LoadingScenePP", LoadSceneMode.Single); //loada loadginscreeen
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enterboat")  //om den kolliderar med något som har taget enterboat
        {
            canExit = true;
        }

        if (collision.gameObject.tag == "båt") //om spelaren (objektet som scriptet sitter på) kolliderar med båt
        {
            if (!Player.deathscreenspawned) //om deathscreen inte är spawnad än
            {
                
                for (int i = 0; i <= PlasticScore.score; i++) //för varje plasticscore
                {
                    Player.money += plasticValue; //lägg till plasticvalue på spelarens pengar.
                }
                for (int i = 0; i <= JewleryScore.score; i++) //för varje jeweleryscore
                {
                    Player.money += JeweleryValue; //lägg till jeweleryvalue på spelarens pengar
                }
                PlasticScore.score = 0; //reseta poäng
                JewleryScore.score = 0; //reseta poäng
                Player.money -= plasticValue; 
                Player.money -= JeweleryValue;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //medans spelaren är på detta
    {
        
        if (collision.gameObject.tag == "water")
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enterboat")
        {
            canExit = false;
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
