using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public float speed = 2;
    public int money;

    //TUBE
    public bool inWater;
    public float maxTube = 15;
    public float tubeRemaining;
    public bool isFilled;


    // Start is called before the first frame update
    void Start()
    {
        
        maxTube = 15;
        speed = 2;
        tubeRemaining = maxTube;

    }

    // Update is called once per frame
    void Update()
    {
        if (inWater)
        {
            tubeRemaining -= 1 * Time.deltaTime;
        }
        else if (!inWater && tubeRemaining != maxTube && tubeRemaining <= maxTube)
        {
            tubeRemaining += 1 * Time.deltaTime;
        }


        if(tubeRemaining <= 0)
        {
            die();
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

    public void die()
    {
        print("you died.");
    }
}
