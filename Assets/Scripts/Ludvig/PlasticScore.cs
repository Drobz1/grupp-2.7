using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlasticScore : MonoBehaviour
{
    public TMP_Text textScore; //hittar texten
    public float score; //variabel  som håller poängen
    

    void Start()
    {
        score = 0f; //sätter score till 0 när man startar spelet. -Ludvig
        textScore.text = score.ToString();  // gör om int till string så man kan skriva ut det
    }

   
    void Update()
    {
        textScore.text = score.ToString();// gör om int till string så man kan skriva ut det /alltid
    }
}
