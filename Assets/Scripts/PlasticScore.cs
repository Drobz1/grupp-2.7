using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlasticScore : MonoBehaviour
{
    public TMP_Text textScore; //hittar texten
    public float score; //variabel  som h�ller po�ngen
    

    void Start()
    {
        score = 0f; //s�tter score till 0 n�r man startar spelet. -Ludvig
        textScore.text = score.ToString();  // g�r om int till string s� man kan skriva ut det
    }

   
    void Update()
    {
        textScore.text = score.ToString();// g�r om int till string s� man kan skriva ut det /alltid
    }
}
