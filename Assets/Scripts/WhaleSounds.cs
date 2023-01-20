using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>(); //referens till audiosource. -Ludvig
         audioSource.PlayDelayed(8); //spelar ljud efter en 8 sekunders delay. -Ludvig

    }


}
