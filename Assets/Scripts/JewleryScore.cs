using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JewleryScore : MonoBehaviour
{
    public TMP_Text textScore; //hittar texten
    public float score; //variabel  som h�ller po�ngen

    // Start is called before the first frame update
    void Start()
    {
        score = 0f; //s�tter score till 0 n�r man startar spelet.
        textScore.text = score.ToString();  // g�r om int till string s� man kan skriva ut det
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = score.ToString();  // g�r om int till string s� man kan skriva ut det
    }
}
