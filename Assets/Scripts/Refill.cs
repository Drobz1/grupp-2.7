using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refill : Shop
{
    public GameObject NotEnoughMoney;
    Player Player;

    public Text priceTag;
    public int refillLevel = 0;
    public int refillValue = 2;
    // Start is called before the first frame update
    void Start()
    {
        itemPrice = 1000;
        raisePrice = 3000;
        Player = FindObjectOfType<Player>();
    }
    public override void buyItem()
    {
        Player.money -= itemPrice;
        itemPrice += raisePrice;
        Player.refillValue = refillValue;
        refillLevel += 1;
    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
    public virtual void clickItem()
    {
        if (Player.money >= itemPrice)
        {
            buyItem();
            print("Bought an item");
        }
        else if (itemPrice > Player.money)
        {
            Instantiate(NotEnoughMoney, transform.position, Quaternion.identity);
            print("You do not have enough money for this item.");
        }
        else
        {
            print("unkown error, couldn't buy item");
        }
    }
}
