using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
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
        SceneManager.LoadScene("CreditsScene");
    }
    //When pressing the Credits button, it changes to the Credits scene - Jay
}
