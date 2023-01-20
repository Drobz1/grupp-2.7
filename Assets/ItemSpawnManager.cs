using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawnManager : MonoBehaviour
{
    //HITTA ALLA PREFABS
    public GameObject trashPrefab;
    public GameObject canPrefab;
    public GameObject plasticPrefab;

    public GameObject ringPrefab;
    public GameObject redNecklacePrefab;
    public GameObject greenNecklacePrefab;


    //INTS SOM ANVÄNDS TILL SENARE
    int randomNumber;
    int randomNumber2;

    Vector3 trashPosition()  //nämner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-33, -114);
        y = Random.Range(13, 0);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }

    Vector3 jeweleryPosition()  //nämner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
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
    void spawnItems() //funktion som spawnar items
    {
        randomNumber = Random.Range(7, 13); //ge randomnumber ett random värde 
        randomNumber2 = Random.Range(2, 4);  //ge randomnumber ett random värde 
        for (int i = 0; i < randomNumber; i++) //för varje randomnumber
        {
            Instantiate(trashPrefab, trashPosition(), Quaternion.identity); //spawna prefab på random position med rätt rotation
            Instantiate(canPrefab, trashPosition(), Quaternion.identity);  //spawna prefab på random position med rätt rotation
            Instantiate(plasticPrefab, trashPosition(), Quaternion.identity);  //spawna prefab på random position med rätt rotation
        }

        for (int i = 0; i < randomNumber2; i++) // för varje randomnumber
        {
            Instantiate(ringPrefab, jeweleryPosition(), Quaternion.identity); //spawna prefab på random position med rätt rotation
            Instantiate(redNecklacePrefab, jeweleryPosition(), Quaternion.identity); //spawna prefab på random position med rätt rotation
            Instantiate(greenNecklacePrefab, jeweleryPosition(), Quaternion.identity); //spawna prefab på random position med rätt rotation
        }



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
