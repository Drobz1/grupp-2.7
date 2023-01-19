using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinaColada : Shop
{
    public Text priceTag;


    public GameObject NotEnoughMoney;
    Player Player;


    public bool boughtPinaColada = false;
    // Start is called before the first frame update
    void Start()
    {
        itemPrice = 100;
        raisePrice = 99899;
        Player = FindObjectOfType<Player>();
    }
    public override void buyItem()
    {
        Player.money -= itemPrice;
        boughtPinaColada = true;
        itemPrice += raisePrice;
        
    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
}
