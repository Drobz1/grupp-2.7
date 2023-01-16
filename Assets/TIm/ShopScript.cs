using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{

    Player Player;

    public int upgradeTubes = 2;
    public Button tubebutton;
    public int tubeprice = 200;

    public int upgradeFlippers = 2;
    public Button flippersbutton;
    public int flippersPrice = 100;

    public int upgradeRefill = 2;
    public Button refillButton;
    public int refillPrice = 1000;

    //NOTIFICATION
    private Text notificationText;


    // Start is called before the first frame update
    void Start()
    {
        notificationText = GetComponent<Text>();
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        notificationText.text = "tja";
    }

    public void buyTubes()
    {
        print("bought tubes");
        Player.money -= tubeprice;
        tubeprice += 200;
        Player.maxTube += 5;

    }
    public void buyFlippers()
    {
        Player.money -= flippersPrice;
        flippersPrice += 100;
        Player.speed += upgradeFlippers;

    }

    public void buyFasterRefill()
    {
        Player.money -= refillPrice;
        Player.refillValue = 2;
        refillButton.gameObject.SetActive(false);
    }
}
