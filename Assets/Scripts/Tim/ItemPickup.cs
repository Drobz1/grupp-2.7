using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    ItemSpawnManager ItemSpawnManager;
    private PlasticScore scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<PlasticScore>(); // Hittar "Canvas" i hierarchy genom Gameobject.Find. Tar också "PlasticScore" som ligger i canvas för att veta vilken text som ska uppdateras. -Ludvig
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //när saker med denna skript kolliderar med någon med tag "Player" så ger den 1 poäng och förstör objektet. -Ludvig
        {
            ItemSpawnManager.randomNumber -= 1;
            scoreManager.score += 1f; 

            Destroy(gameObject);
        }
    }
}
