using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public int money;

    //TUBE
    public float filledTube = 15;
    public float tubeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("filled tube is" + filledTube);
        print("speed is " + speed);
    }
}
