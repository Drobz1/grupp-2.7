using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{

    Player Player;
    public GameObject NotEnoughMoney;

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
        //notificationText.text = "tja";
    }
    public void buyTubes()
    {
        if(Player.money >= tubeprice)
        {
            print("bought tubes");
            Player.money -= tubeprice;
            tubeprice += 200;
            Player.maxTube += 5;
            if (!Player.tubeEquipped)
            {
                Player.tubeEquipped = true;
            }
        }
        else
        {
            Instantiate(NotEnoughMoney, transform.position, Quaternion.identity);

        }



    }
    public void buyFlippers()
    {
        if (Player.money >= flippersPrice)
        {
            Player.money -= flippersPrice;
            flippersPrice += 100;
            Player.speed += upgradeFlippers;
        }
        else
        {
            Instantiate(NotEnoughMoney, transform.position, Quaternion.identity);
        }
    }

    public void buyFasterRefill()
    {
        if(Player.money >= refillPrice)
        {
            Player.money -= refillPrice;
            Player.refillValue = 2;
            refillButton.gameObject.SetActive(false);
        }
        else
        {
            Instantiate(NotEnoughMoney, transform.position, Quaternion.identity);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.2f);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
