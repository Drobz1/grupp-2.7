using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonStart()
    {
        SceneManager.LoadScene("LoreScreen");
    }
    //When pressing the Start button, it changes to the Lore scene - Jay
}
