using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreditsStart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //When pressing the back button, it changes to the main menu - Jay
}
