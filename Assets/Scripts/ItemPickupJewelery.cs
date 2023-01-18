using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupJewelery : MonoBehaviour
{

    private JeweleryScore JeweleryScore;
    // Start is called before the first frame update
    void Start()
    {
        JeweleryScore = GameObject.Find("Jewelery").GetComponent<JeweleryScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //n�r saker med denna skript kolliderar med n�gon med tag "Player" s� ger den 1 po�ng och f�rst�r objektet. -Ludvig
        {
            JeweleryScore.score += 1f;  
            Destroy(gameObject);
        }
    }
}
