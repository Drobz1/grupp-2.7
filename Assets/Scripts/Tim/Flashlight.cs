using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : Shop
{
    public Text priceTag;
    public static int goggleLevel = 0;


    public GameObject NotEnoughMoney;
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        goggleLevel = 0;    
        raisePrice = 500;
        Player = FindObjectOfType<Player>();
        itemPrice = Player.gogglesLevel * 500 + 500;
    }
    public override void buyItem()
    {
        base.buyItem();
        Player.flashlightLevel += 1;
        //Player.zoomValue += 1.5f;
        gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
    }
}
