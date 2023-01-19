using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
    [SerializeField]
    int buildindex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(buildindex);
        }
    }
    //After a certain ammount of time, it changes scene to the build index number indicated - Jay
}