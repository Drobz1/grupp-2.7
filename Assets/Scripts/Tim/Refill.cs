using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refill : Shop
{
    //Detta script �r gjort av Tim S SU21B och �rver fr�n "Shop". Detta script g�r att man kan k�pa Refill

    public GameObject NotEnoughMoney;
    Player Player;

    public Text priceTag;
    public static int refillLevel = 0;
    public float refillValue = 2;
    // Start is called before the first frame update
    void Start()
    {
        raisePrice = 1000;
        Player = FindObjectOfType<Player>();
        itemPrice = Player.refillLevel * 1000 + 1000;
    }
    public override void buyItem()
    {
        base.buyItem();
        Player.refillValue = refillValue;
        Player.refillLevel += 1;

    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
    
}
