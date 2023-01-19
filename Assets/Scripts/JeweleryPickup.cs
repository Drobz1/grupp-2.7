using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeweleryPickup : MonoBehaviour
{
    private JewleryScore JewleryScore; //referens till jeweleryscroe

    // Start is called before the first frame update
    void Start()
    {
        JewleryScore = GameObject.Find("Jewelery").GetComponent<JewleryScore>(); // Hittar "Canvas" i hierarchy genom Gameobject.Find. Tar också "PlasticScore" som ligger i canvas för att veta vilken text som ska uppdateras. 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //när saker med denna skript kolliderar med någon med tag "Player" så ger den 1 poäng och förstör objektet. 
        {
            JewleryScore.score += 1f; //lägger på ett poäng
            Destroy(gameObject); //tar bort objektet
        }
    }

}
