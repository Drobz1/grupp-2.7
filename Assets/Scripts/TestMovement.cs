using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float jumpheight = 5f;
    public Rigidbody2D rb;

    AudioSource hoppljud;

    public float movespeed = 10; //hur snabbt man rör sig åt sidorna. - Ludvig

    public const string Right = "right";
    public const string Left = "left";

    string buttonpressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //referens till rigidbody på player. - Ludvig
        hoppljud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D)) //gör så tangenten "D" rör spelaren åt höger. Ludvig
        {
            buttonpressed = Right;
        }
        else if (Input.GetKey(KeyCode.A)) //gör så tangenten "A" rör spelaren åt vänster. -Ludvig
        {
            buttonpressed = Left;
        }
        else //gör så all movement stoppas när man inte håller in eller klickar på en knapp. -Ludvig
        {
            buttonpressed = null;
        }
        if (buttonpressed == Right) //använder den value på movespeed för att flytta player åt höger med hjälp av velocity. -Ludvig
        {
            rb.velocity = new Vector3(movespeed, rb.velocity.y, 0);
        }
        else if (buttonpressed == Left) //använde den value på movespeed fast motsatt speed vilket flyttar player åt vänster med velocity. -Ludvig
        {
            rb.velocity = new Vector3(-movespeed, rb.velocity.y, 0);
        }
        else //"buttonpressed = null" och denna kod gör så spelaren inte fortsätter röra sig åt vänster eller höger även när du släppt knapparna. -Ludvig
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

      
    }


    private bool IsGrounded() // lägger till en bool som kollar om du är på marken eller i luften. - Ludvig
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, new Vector3(transform.position.x, -1000, transform.position.z)); //skapar en ny racast som är riktad neråt från player och kollar om Player är grounded eller inte. -Ludvig

        if (Physics.Raycast(ray, out hit, 0.6f))
        {
            if (hit.collider != null) // om player är i kontakt med något som har en collider så säger den att det är ground så den kan hoppa. -Ludvig
            {
                return true;
            }
        }
        return false;
    }
}

