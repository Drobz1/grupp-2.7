using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float jumpheight = 5f;
    public Rigidbody2D rb;

    AudioSource hoppljud;

    public float movespeed = 10; //hur snabbt man r�r sig �t sidorna. - Ludvig

    public const string Right = "right";
    public const string Left = "left";

    string buttonpressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //referens till rigidbody p� player. - Ludvig
        hoppljud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D)) //g�r s� tangenten "D" r�r spelaren �t h�ger. Ludvig
        {
            buttonpressed = Right;
        }
        else if (Input.GetKey(KeyCode.A)) //g�r s� tangenten "A" r�r spelaren �t v�nster. -Ludvig
        {
            buttonpressed = Left;
        }
        else //g�r s� all movement stoppas n�r man inte h�ller in eller klickar p� en knapp. -Ludvig
        {
            buttonpressed = null;
        }
        if (buttonpressed == Right) //anv�nder den value p� movespeed f�r att flytta player �t h�ger med hj�lp av velocity. -Ludvig
        {
            rb.velocity = new Vector3(movespeed, rb.velocity.y, 0);
        }
        else if (buttonpressed == Left) //anv�nde den value p� movespeed fast motsatt speed vilket flyttar player �t v�nster med velocity. -Ludvig
        {
            rb.velocity = new Vector3(-movespeed, rb.velocity.y, 0);
        }
        else //"buttonpressed = null" och denna kod g�r s� spelaren inte forts�tter r�ra sig �t v�nster eller h�ger �ven n�r du sl�ppt knapparna. -Ludvig
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

      
    }


    private bool IsGrounded() // l�gger till en bool som kollar om du �r p� marken eller i luften. - Ludvig
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, new Vector3(transform.position.x, -1000, transform.position.z)); //skapar en ny racast som �r riktad ner�t fr�n player och kollar om Player �r grounded eller inte. -Ludvig

        if (Physics.Raycast(ray, out hit, 0.6f))
        {
            if (hit.collider != null) // om player �r i kontakt med n�got som har en collider s� s�ger den att det �r ground s� den kan hoppa. -Ludvig
            {
                return true;
            }
        }
        return false;
    }
}

