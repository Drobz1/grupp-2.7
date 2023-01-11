using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{

    Player Player;

    public int level2tubes;
    public Button tubebutton;
    public int tubeprice = 200;

    public int level2flippers;
    public Button flippersbutton;
    public int flippersprice = 100;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyTubes()
    {
        Player.money -= tubeprice;
        Player.filledTube = level2tubes;
        print("Bought level 2 tubes");
        tubebutton.gameObject.SetActive(false);
    }
    public void buyFlippers()
    {
        Player.money -= flippersprice;
        Player.speed = level2flippers;
        print("Bought level 2 flippers");
        flippersbutton.gameObject.SetActive(false);
    }
}
