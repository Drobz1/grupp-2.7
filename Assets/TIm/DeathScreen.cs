using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public float minimum = 0.0f; 
    public float maximum = 1f;
    public float duration = 9.0f;
    private float startTime;    
    public SpriteRenderer sprite;

    Player Player;


// Start is called before the first frame update
void Start()
    {
        Player = FindObjectOfType<Player>();
        startTime = Time.time; //starttiden baseras på den riktiga tiden
        StartCoroutine(SelfDestruct()); //starta couroutine selfdestruct
    }
    IEnumerator SelfDestruct() //en timer enkel timer som bestämmer hur lång scenen ska vara
    {
        float b = (Time.time - startTime) / duration; //timer
        yield return new WaitForSeconds(9f); //pausa i 9 sekunder
        //loada nästa scen
    }

    void Update()
    {
            sprite.color = new Color(1f, 1f, 1f);
            float t = (Time.time - startTime) / duration; //timer
            sprite.color = new Color(0f, 0f, 0f, Mathf.SmoothStep(minimum, maximum, t)); //fadea in spriten


        
    }

    
    public void die()
    {
        sprite.color = new Color(1f, 1f, 1f);
        startTime = Time.time; //starttiden baseras på den riktiga tiden
        StartCoroutine(SelfDestruct()); //starta couroutine selfdestruct
    }
}
