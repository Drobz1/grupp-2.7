using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Shop : MonoBehaviour
{
    //HELA DETTA SCRIPT �R GJORT AV TIM S SU21B
    //HELA DETTA SCRIPT �R GJORT AV TIM S SU21B
    //HELA DETTA SCRIPT �R GJORT AV TIM S SU21B
    
    //Detta script �r uppbyggt p� arv, det finns upgrades som �rver fr�n detta script. Klicka p� "9 references" n�gra rader ovan f�r att se vad som �rver fr�n detta.

    //Variabler f�r aff�ren
    Player Player;
    public int itemPrice;
    public int raisePrice;
    public static int latestPrice;

    public GameObject notEnoughMoney;
    public TMP_Text balanceText;
    public GameObject moneyDrawn;

    public AudioSource buysound;

    void Start()
    {
        Player = FindObjectOfType<Player>();
        buysound = FindObjectOfType<AudioSource>();
    }


    void Update()
    {
        balanceText.text = "Balance: " + Player.money;
    }
   
    public virtual void buyItem() //k�p item
    {
        if(Player.money >=  itemPrice) //om spelarens pengar �r mer �n kostnaden p� objektet
        {
            Player.money -= itemPrice ; //subtrahera spelarens pengar med kostnaden p� objektet
            latestPrice = itemPrice; //best�m ett latestprice (till "MoneyDrawn" scriptet)
            itemPrice += raisePrice; //addera raiseprice till itemprice, s� att det blir dyrare och dyrare. 
            buysound.Play(); //Spela "k�p" ljudet


            Instantiate(moneyDrawn, new Vector3(0, -2.34f, 0), Quaternion.identity);
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
