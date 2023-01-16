using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinaColada : Shop
{
    public GameObject NotEnoughMoney;
    Player Player;

    public bool boughtPinaColada = false;
    // Start is called before the first frame update
    void Start()
    {
        itemPrice = 100;
        raisePrice = 3000;
        Player = FindObjectOfType<Player>();
    }
    public override void buyItem()
    {
        Player.money -= itemPrice;
        boughtPinaColada = true;
        transform.position = new Vector3(1000, 1000, 1000);
        
    }
    // Update is called once per frame
    void Update()
    {

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
