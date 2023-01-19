using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        destroyText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroyText()
    {
        Destroy(gameObject, 2);
    }
}
