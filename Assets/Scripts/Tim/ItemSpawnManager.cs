using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawnManager : MonoBehaviour
{

    //DETTA SCRIPT ?R GJORT AV TIM S SU21B
    //DETTA SCRIPT ?R GJORT AV TIM S SU21B
    //DETTA SCRIPT ?R GJORT AV TIM S SU21B

    //HITTA ALLA PREFABS
    public GameObject trashPrefab;
    public GameObject canPrefab;
    public GameObject plasticPrefab;

    public GameObject ringPrefab;
    public GameObject redNecklacePrefab;
    public GameObject greenNecklacePrefab;

    public int totalItemsOnMap;

    //INTS SOM ANV?NDS TILL SENARE
    public int randomNumber;
    public int randomNumber2;
    

    Vector3 trashPosition()  //n?mner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-33, -114);
        y = Random.Range(13, 0);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }

    Vector3 jeweleryPosition()  //n?mner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-33, -114);
        y = Random.Range(0, -8);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }
    Vector3 treasurePosition()  //n?mner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-33, -114);
        y = Random.Range(28, 36);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }


    // Start is called before the first frame update
    void Start()
    {
        totalItemsOnMap = 0;
        spawnItems();
    }
    void spawnItems() //funktion som spawnar items
    {
        randomNumber = Random.Range(7, 13); //ge randomnumber ett random v?rde 
        randomNumber2 = Random.Range(2, 4);  //ge randomnumber ett random v?rde
       
        for (int i = 0; i < randomNumber; i++) //f?r varje randomnumber
        {
            Instantiate(trashPrefab, trashPosition(), Quaternion.identity); //spawna prefab p? random position med r?tt rotation
            Instantiate(canPrefab, trashPosition(), Quaternion.identity);  //spawna prefab p? random position med r?tt rotation
            Instantiate(plasticPrefab, trashPosition(), Quaternion.identity);  //spawna prefab p? random position med r?tt rotation
            totalItemsOnMap += 3; 
        }

        for (int i = 0; i < randomNumber2; i++) // f?r varje randomnumber
        {
            Instantiate(ringPrefab, jeweleryPosition(), Quaternion.identity); //spawna prefab p? random position med r?tt rotation
            Instantiate(redNecklacePrefab, jeweleryPosition(), Quaternion.identity); //spawna prefab p? random position med r?tt rotation
            Instantiate(greenNecklacePrefab, jeweleryPosition(), Quaternion.identity); //spawna prefab p? random position med r?tt rotation
            totalItemsOnMap += 3;
        }
        for (int i = 0; i < 350; i++)
        {
           /* Instantiate(ringPrefab, treasurePosition(), Quaternion.identity); //spawna prefab p? random position med r?tt rotation
            Instantiate(redNecklacePrefab, treasurePosition(), Quaternion.identity); //spawna prefab p? random position med r?tt rotation
            Instantiate(greenNecklacePrefab, treasurePosition(), Quaternion.identity); //spawna prefab p? random position med r?tt rotation
       */
            }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.U))
            {
            print(totalItemsOnMap);
        }
    }
}
