using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDrawn : MonoBehaviour
{
    //HELA DETTA SCRIPT ÄR GJORT AV TIM S SU21B
    //HELA DETTA SCRIPT ÄR GJORT AV TIM S SU21B
    //HELA DETTA SCRIPT ÄR GJORT AV TIM S SU21B

    //Referenser
    Player Player;
    Shop Shop;
    public TextMesh moneyDrawnMesh; //Texten som ska användas
    public float timer = 1;
    // Start is called before the first frame update
    public byte fade = 255;
        Color Fadeout;

    void Start()
    {
        Fadeout = new Color32(255, 255, 255, 255); 

        timer = 2;
        Shop = FindObjectOfType<Shop>();
        Player = FindObjectOfType<Player>();

        moneyDrawnMesh.text = "-" + Shop.latestPrice; //Texten som kommer fram är samma sak som - och sedan pengarna som senast drogs

    }

    // Update is called once per frame
    void Update() 
    {
        Fadeout = new Color32(255, 255, 255, fade);

        transform.position += new Vector3(0, 0.02f, 0); //gå upp hela tiden
        fade -= 1;
        moneyDrawnMesh.color = Fadeout;
        
        if(fade == 0) //om fade är 0 (fadeat ut helt) ta bort objektet.
        {
            Destroy(gameObject);
        }
    }
}
