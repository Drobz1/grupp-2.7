using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool dead = false;

    public float speed = 2;
    public int money;

    //TUBE
    public bool tubeEquipped;
    public bool inWater;
    public float maxTube = 15;
    public float tubeRemaining;
    public bool isFilled;
    public float refillValue = 1;

    public bool deathscreenspawned = false;
    DeathScreen DeathScreen;
    public GameObject deathscreenprefab;
    // Start is called before the first frame update
    void Start()
    {
        DeathScreen = FindObjectOfType<DeathScreen>();
        maxTube = 15;
        speed = 2;
        tubeRemaining = maxTube;
        dead = false;
        money = 1000;


    }

    // Update is called once per frame
    void Update()
    {
        if (inWater)
        {
            if(tubeEquipped)
            {
                tubeRemaining -= 1 * Time.deltaTime;
            }
            else if (!tubeEquipped)
            {
                tubeRemaining -= 3 * Time.deltaTime;
            }
        }

        else if (!inWater && tubeRemaining != maxTube && tubeRemaining <= maxTube)
        {
            tubeRemaining += refillValue * Time.deltaTime;
        }


        if(tubeRemaining <= 0)
        {
            if(!deathscreenspawned)
            {
                Instantiate(deathscreenprefab, new Vector3(0, 0, 0), Quaternion.identity);
                deathscreenspawned = true;
            }
            



        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            inWater = true;
        }
        if(Input.GetKeyUp(KeyCode.O))
        {
            inWater = false;
        }

        print("filled tube is" + maxTube);
        print("speed is " + speed);
    }
}
