using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   
    private PlasticScore scoreManager;
    Player Player;

    private void Start()
    {
        Player = FindObjectOfType<Player>();
        scoreManager = GameObject.Find("Canvas").GetComponent<PlasticScore>(); // Hittar "Canvas" i hierarchy genom Gameobject.Find. Tar också Skripten "PlasticScore" 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scoreManager.score += 1f; 
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Player.inWater == false)
        {
            scoreManager.score = 0;
            for (int i = 0; i < scoreManager.score; i++)
            {
                Player.money += 50;
            }
        }
    }
}
