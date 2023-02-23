using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : Shop
{
    public Text priceTag;
    public static int flashLightLevel = 0;


    public GameObject NotEnoughMoney;
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        flashLightLevel = 0;
        raisePrice = 100;
        Player = FindObjectOfType<Player>();
        itemPrice = Player.flashlightLevel * 500 + 100;
        if(Player.flashlightLevel >= 1)
        {
            gameObject.SetActive(false);
        }
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
