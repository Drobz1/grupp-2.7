using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   
    private PlasticScore scoreManager;

    private void Start()
    {
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
}
