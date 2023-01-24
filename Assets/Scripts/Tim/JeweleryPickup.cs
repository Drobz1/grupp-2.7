using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeweleryPickup : MonoBehaviour
{
    private JewleryScore JewleryScore; //referens till jeweleryscroe

    // Start is called before the first frame update
    void Start()
    {
        JewleryScore = GameObject.Find("Jewelery").GetComponent<JewleryScore>(); // Hittar "Canvas" i hierarchy genom Gameobject.Find. Tar ocks� "PlasticScore" som ligger i canvas f�r att veta vilken text som ska uppdateras. 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //n�r saker med denna skript kolliderar med n�gon med tag "Player" s� ger den 1 po�ng och f�rst�r objektet. 
        {
            JewleryScore.score += 1f; //l�gger p� ett po�ng
            Destroy(gameObject); //tar bort objektet
        }
    }

}
