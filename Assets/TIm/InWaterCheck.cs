using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWaterCheck : MonoBehaviour
{
    public Rigidbody2D rb;

    Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            Player.inWater = true;
            Player.rb.gravityScale = 1f;
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
        }
    }
}
