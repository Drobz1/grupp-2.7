using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
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
        SceneManager.LoadScene("LoadingSceneRight");
    }
    //When pressing the Continue button, it changes to the Loading screen - Jay
}
