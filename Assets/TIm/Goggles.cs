using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goggles : Shop
{

    public Text priceTag;

    public Camera m_OrthographicCamera;
    public float zoomValue = 3f;

    public GameObject NotEnoughMoney;
    Player Player;
    // Start is called before the first frame update
    void Start()
    {
        itemPrice = 100;
        raisePrice = 200;
        Player = FindObjectOfType<Player>();
    }

    public override void buyItem()
    {
        Player.money -= itemPrice;
        itemPrice += raisePrice;
        //Player.zoomValue += 1.5f;

    }
    // Update is called once per frame
    void Update()
    {
        priceTag.text = "Price: $" + itemPrice;
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
            Instantiate(NotEnoughMoney, transform.position, Quaternion.identity);
            print("You do not have enough money for this item.");
        }
        else
        {
            print("unkown error, couldn't buy item");
        }
    }
}