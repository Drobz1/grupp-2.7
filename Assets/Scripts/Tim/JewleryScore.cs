using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JewleryScore : MonoBehaviour
{
    public TMP_Text textScore; //hittar texten
    public float score; //variabel  som håller poängen

    // Start is called before the first frame update
    void Start()
    {
        score = 0f; //sätter score till 0 när man startar spelet.
        textScore.text = score.ToString();  // gör om int till string så man kan skriva ut det
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = score.ToString();  // gör om int till string så man kan skriva ut det
    }
}
