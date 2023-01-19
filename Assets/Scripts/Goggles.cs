using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goggles : Shop
{

    public Text priceTag;
    public static int goggleLevel = 0;


    public GameObject NotEnoughMoney;
    Player Player;
    // Start is called before the first frame update
    void Start()
    {
        goggleLevel = 0;
        itemPrice = 100;
        raisePrice = 200;
        Player = FindObjectOfType<Player>();
    }

    public override void buyItem()
    {
        Player.money -= itemPrice;
        itemPrice += raisePrice;
        Player.gogglesLevel += 1;
        //Player.zoomValue += 1.5f;

    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
    
}
