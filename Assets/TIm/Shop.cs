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

    public TMP_Text balanceText;
    void Start()
    {
        Player = FindObjectOfType<Player>();

    }


    void Update()
    {
        balanceText.text = "Balance: $" + Player.money;
    }
   
    public virtual void buyItem()
    {
        Player.money -= itemPrice;
        itemPrice += raisePrice;
    }

}
