using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlasticScore : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;
    

    void Start()
    {
        score = 0f; //sätter score till 0 när man startar spelet. -Ludvig
        textScore.text = score.ToString(); 
    }

   
    void Update()
    {
        textScore.text = score.ToString();
    }
}
