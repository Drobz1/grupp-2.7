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
   
    public virtual void buyItem() //köp item
    {
        if(Player.money >= itemPrice) //om spelarens pengar är mer än kostnaden på objektet
        { 
            Player.money -= itemPrice; //subtrahera spelarens pengar med kostnaden på objektet
            itemPrice += raisePrice; //addera raiseprice till itemprice, så att det blir dyrare och dyrare. 
        }
        else
        {
            Instantiate(notEnoughMoney, transform.position, Quaternion.identity); //annars spawna texten som visar att man har för lite pengar. 
        }
    }

    public virtual void clickItem() //klicka på knappen för att köpa
    {
        if (Player.money >= itemPrice) //om spelarens pengar är större än itemprice
        {
            buyItem(); //köp item
            print("Bought an item"); 
        }
        else if (itemPrice > Player.money) //om det är för dyrt
        {
            Instantiate(notEnoughMoney, transform.position, Quaternion.identity);//annars spawna texten som visar att man har för lite pengar. 
            print("You do not have enough money for this item.");
        }
        else
        {
            print("unkown error, couldn't buy item");
        }
    }
}
