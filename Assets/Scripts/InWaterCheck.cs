using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InWaterCheck : MonoBehaviour
{
    //Niljas fixade gravity
    public Rigidbody2D rb;

    private int plasticValue = 50;
    private int JeweleryValue = 100;

    PlasticScore PlasticScore;
    JewleryScore JewleryScore;
    Player Player;
    public bool canExit = false;
    // Start is called before the first frame update
    void Start()
    {
        PlasticScore = FindObjectOfType<PlasticScore>();
        JewleryScore = FindObjectOfType<JewleryScore>();
        Player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "båt")
        {
            if (!Player.deathscreenspawned)
            {
                canExit = true;
                for (int i = 0; i <= PlasticScore.score; i++)
                {
                    Player.money += plasticValue;
                }
                for (int i = 0; i <= JewleryScore.score; i++)
                {
                    Player.money += JeweleryValue;
                }
                PlasticScore.score = 0;
                JewleryScore.score = 0;
                Player.money -= plasticValue;
                Player.money -= JeweleryValue;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enterboat")
        {
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(Player.deathscreenspawned == false)
                {
                    print("entered the boat");
                    SceneManager.LoadScene("LoadingScenePP", LoadSceneMode.Single);
                }

            }
        }
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
