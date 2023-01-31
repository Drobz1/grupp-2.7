using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class flashlight : MonoBehaviour
{
    bool flip;

    SpriteRenderer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flip = player.flipX;
        if (flip)
        {
            transform.localPosition = new Vector3(-0.25f,0.09f,0f);
            transform.localRotation = Quaternion.Euler( new Vector3(0f, 0f, 89.407f));
            print("lampa vänster");
        }
        else
        {
            transform.localPosition = new Vector3(0.25f, 0.09f, 0f);
            transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -89.407f));
            print("lampa höger");
        }
    }
}
