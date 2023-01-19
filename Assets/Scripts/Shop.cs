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
   
    public virtual void buyItem() //k�p item
    {
        if(Player.money >= itemPrice) //om spelarens pengar �r mer �n kostnaden p� objektet
        { 
            Player.money -= itemPrice; //subtrahera spelarens pengar med kostnaden p� objektet
            itemPrice += raisePrice; //addera raiseprice till itemprice, s� att det blir dyrare och dyrare. 
        }
        else
        {
            Instantiate(notEnoughMoney, transform.position, Quaternion.identity); //annars spawna texten som visar att man har f�r lite pengar. 
        }
    }

    public virtual void clickItem() //klicka p� knappen f�r att k�pa
    {
        if (Player.money >= itemPrice) //om spelarens pengar �r st�rre �n itemprice
        {
            buyItem(); //k�p item
            print("Bought an item"); 
        }
        else if (itemPrice > Player.money) //om det �r f�r dyrt
        {
            Instantiate(notEnoughMoney, transform.position, Quaternion.identity);//annars spawna texten som visar att man har f�r lite pengar. 
            print("You do not have enough money for this item.");
        }
        else
        {
            print("unkown error, couldn't buy item");
        }
    }
}
