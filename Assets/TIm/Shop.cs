using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Player Player;
    public int itemPrice;
    public int raisePrice;

    void Start()
    {
        Player = FindObjectOfType<Player>();
    }


    void Update()
    {
        
    }
   
    public virtual void buyItem()
    {
        Player.money -= itemPrice;
        itemPrice += raisePrice;
    }

}
