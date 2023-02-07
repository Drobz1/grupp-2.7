using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDrawn : MonoBehaviour
{
    Player Player;
    Shop Shop;
    public TextMesh moneyDrawnMesh;
    public float timer = 1;
    // Start is called before the first frame update
    public byte fade = 255;
        Color Fadeout;

    void Start()
    {
        Fadeout = new Color32(255, 255, 255, 255);

        timer = 2;
        Shop = FindObjectOfType<Shop>();
        Player = FindObjectOfType<Player>();

        moneyDrawnMesh.text = "-" + Shop.latestPrice;

    }

    // Update is called once per frame
    void Update()
    {
        if( fade <= 0)
        {
            transform.position = new Vector3(1000, 1000, 1000);
        }
        Fadeout = new Color32(255, 255, 255, fade);

        transform.position += new Vector3(0, 0.015f, 0);
        fade -= 1;
        moneyDrawnMesh.color = Fadeout;
        

    }
}
