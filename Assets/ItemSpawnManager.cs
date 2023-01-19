using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject trashPrefab;
    public GameObject canPrefab;
    public GameObject plasticPrefab;

    public GameObject ringPrefab;
    public GameObject redNecklacePrefab;
    public GameObject greenNecklacePrefab;

    Vector3 trashPosition()  //n�mner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-33, -114);
        y = Random.Range(13, 0);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }

    Vector3 jeweleryPosition()  //n�mner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-33, -114);
        y = Random.Range(0, -8);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnItems();
    }
    void spawnItems()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(trashPrefab, trashPosition(), Quaternion.identity);
            Instantiate(canPrefab, trashPosition(), Quaternion.identity);
            Instantiate(plasticPrefab, trashPosition(), Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)
        {
            Instantiate(ringPrefab, jeweleryPosition(), Quaternion.identity);
            Instantiate(redNecklacePrefab, jeweleryPosition(), Quaternion.identity);
            Instantiate(greenNecklacePrefab, jeweleryPosition(), Quaternion.identity);
        }



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
