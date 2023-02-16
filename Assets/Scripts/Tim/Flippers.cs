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
        raisePrice = 200;
        Player = FindObjectOfType<Player>();
        itemPrice = Player.flippersLevel * 200 + 200;

    }
    public override void buyItem()
    {
        base.buyItem();
        
        Player.speed += 0.2f;
        Player.flippersLevel += 1;
    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
    
}
