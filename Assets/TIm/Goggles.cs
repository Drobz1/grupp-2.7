using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goggles : MonoBehaviour
{

    public Camera m_OrthographicCamera;
    public float zoomValue = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_OrthographicCamera.orthographicSize = zoomValue;
    }
}
