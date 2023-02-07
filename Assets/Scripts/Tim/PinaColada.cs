using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinaColada : Shop
{
    public Text priceTag;

    static bool pinaBought = false;
    public GameObject NotEnoughMoney;
    Player Player;


    public bool boughtPinaColada = false;
    // Start is called before the first frame update
    void Start()
    {
        if(pinaBought == true)
        {
            priceTag.text = "Drunk mf";
        }
        itemPrice = 100;
        raisePrice = 99899;
        Player = FindObjectOfType<Player>();
    }
    public override void buyItem()
    {
        base.buyItem();
        boughtPinaColada = true;

        pinaBought = true;


    }
    // Update is called once per frame
    void Update()
    {
        if( pinaBought == false)
        {
            priceTag.text = "Price: $" + itemPrice; 
        }
        else if (pinaBought == true)
        {
            priceTag.text = "Drunk mf";
        }

    }
}
