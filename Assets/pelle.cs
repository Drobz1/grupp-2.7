using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelle : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!sprite.flipX)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }
}