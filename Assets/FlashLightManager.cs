using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightManager : MonoBehaviour
{
    Player Player;
    [SerializeField] GameObject flashLight;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>();
        flashLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.flashlightLevel >= 1) //Om man har k�pt flashlight en g�ng  -- Tim
        {
            flashLight.gameObject.SetActive(true); //S�tt den aktiv  -- Tim
        }
    }
}
