using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flippers : Shop
{
    public GameObject NotEnoughMoney;
    Player Player;

    public Text priceTag;
    public static int flippersLevel = 0;
    public int speedGain = 2;
    // Start is called before the first frame update
    void Start()
    {
        flippersLevel = 0;
        itemPrice = 200;
        raisePrice = 200;
        Player = FindObjectOfType<Player>();
    }
    public override void buyItem()
    {
        Player.money -= itemPrice;
        itemPrice += raisePrice;
        Player.speed += 0.5f;
        Player.flippersLevel += 1;
    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
    
}
