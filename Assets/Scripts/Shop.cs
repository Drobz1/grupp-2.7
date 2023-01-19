using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Shop : MonoBehaviour
{
    Player Player;
    public int itemPrice;
    public int raisePrice;

    public GameObject notEnoughMoney;
    public TMP_Text balanceText;
    void Start()
    {
        Player = FindObjectOfType<Player>();

    }


    void Update()
    {
        balanceText.text = "Balance: " + Player.money;
    }
   
    public virtual void buyItem()
    {
        if(Player.money >= itemPrice)
        {
            Player.money -= itemPrice;
            itemPrice += raisePrice;
        }
        else
        {
            Instantiate(notEnoughMoney, transform.position, Quaternion.identity);
        }
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
            Instantiate(notEnoughMoney, transform.position, Quaternion.identity);
            print("You do not have enough money for this item.");
        }
        else
        {
            print("unkown error, couldn't buy item");
        }
    }
}
