using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tubes : Shop
{
    //public GameObject NotEnoughMoney;
    Player Player;

    public Text priceTag;


    // Start is called before the first frame update
    void Start()
    {
        raisePrice = 200;
        Player = FindObjectOfType<Player>();
        itemPrice = Player.tubeLevel * 200 + 200;
    }
    public override void buyItem()
    {
        if(Player.tubeEquipped == false)
        {
            Player.tubeEquipped = true;
        }
        Player.money -= itemPrice;
        itemPrice += raisePrice;
        Player.maxTube += 5;
        Player.tubeLevel += 1;
    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
}
