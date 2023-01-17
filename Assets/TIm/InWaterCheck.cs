using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWaterCheck : MonoBehaviour
{
    //Niljas fixade gravity
    public Rigidbody2D rb;

    PlasticScore PlasticScore;
    Player Player;
    // Start is called before the first frame update
    void Start()
    {
        PlasticScore = FindObjectOfType<PlasticScore>();
        Player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "båt")
        {

            for (int i = 0; i <= PlasticScore.score; i = i++)
            {
                print("hej");
            }
            PlasticScore.score = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
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
        if(collision.gameObject.tag == "water")
        {
            Player.inWater = false;
            Player.rb.gravityScale = 1f;
            Player.movespeed = 0f;
            Player.reversespeed = 0f;
            Player.swimDown = 0f;
            Player.swimUp = 0f;
        }
    }
}
