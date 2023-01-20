using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refill : Shop
{
    public GameObject NotEnoughMoney;
    Player Player;

    public Text priceTag;
    public static int refillLevel = 0;
    public int refillValue = 2;
    // Start is called before the first frame update
    void Start()
    {
        raisePrice = 1000;
        Player = FindObjectOfType<Player>();
        itemPrice = Player.refillLevel * 1000 + 1000;
    }
    public override void buyItem()
    {
        Player.money -= itemPrice;
        itemPrice += raisePrice;
        Player.refillValue = refillValue;
        Player.refillLevel += 1;
    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
    
}
