using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    ItemSpawnManager ItemSpawnManager;
    private PlasticScore scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<PlasticScore>(); // Hittar "Canvas" i hierarchy genom Gameobject.Find. Tar ocks� "PlasticScore" som ligger i canvas f�r att veta vilken text som ska uppdateras. -Ludvig
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //n�r saker med denna skript kolliderar med n�gon med tag "Player" s� ger den 1 po�ng och f�rst�r objektet. -Ludvig
        {
            ItemSpawnManager.randomNumber -= 1;
            scoreManager.score += 1f; 

            Destroy(gameObject);
        }
    }
}
