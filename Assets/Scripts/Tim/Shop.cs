using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Shop : MonoBehaviour
{
    //HELA DETTA SCRIPT ÄR GJORT AV TIM S SU21B
    //HELA DETTA SCRIPT ÄR GJORT AV TIM S SU21B
    //HELA DETTA SCRIPT ÄR GJORT AV TIM S SU21B
    
    //Detta script är uppbyggt på arv, det finns upgrades som ärver från detta script. Klicka på "9 references" några rader ovan för att se vad som ärver från detta.

    //Variabler för affären
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
   
    public virtual void buyItem() //köp item
    {
        if(Player.money >=  itemPrice) //om spelarens pengar är mer än kostnaden på objektet
        {
            Player.money -= itemPrice ; //subtrahera spelarens pengar med kostnaden på objektet
            latestPrice = itemPrice; //bestäm ett latestprice (till "MoneyDrawn" scriptet)
            itemPrice += raisePrice; //addera raiseprice till itemprice, så att det blir dyrare och dyrare. 
            buysound.Play(); //Spela "köp" ljudet


            Instantiate(moneyDrawn, new Vector3(0, -2.34f, 0), Quaternion.identity);
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
