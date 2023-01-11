using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{

    Player Player;

    public int level2tubes;
    public Button tubebutton;

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
        Player.money -= 200;
        Player.filledTube = level2tubes;
        print("Bought level 2 tubes");
        tubebutton.gameObject.SetActive(false);
        
        
    }
}
