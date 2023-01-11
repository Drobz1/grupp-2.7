using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject cam;

    [SerializeField, Range (1,10)]
    float speed;
    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 4, 0) * Time.deltaTime;
            print("W was executed.");
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 4, 0) * Time.deltaTime;
            print("S was executed");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(4, 0, 0) * Time.deltaTime;
            print("D was executed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(4, 0, 0) * Time.deltaTime;
            print("A was executed");
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            cam.transform.position = new Vector3(74.6f, 0, -10);
        }
    }
}
