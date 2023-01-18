using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{

    public GameObject burkPrefab;
    public GameObject plastPrefab;
    public GameObject trashPrefab;

    public GameObject ringPrefab;
    public GameObject necklaceRedPrefab;
    public GameObject necklaceGreenPrefab;


    Vector3 trashRandomPosition()  //nämner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-18, -91);
        y = Random.Range(14, 1);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }

    Vector3 jeweleryRandomPosition()  //nämner ut ett antal koordinater, emellan de koordinaterna blir en random punkt utvald.
    {
        int x, y, z;
        x = Random.Range(-91, -18);
        y = Random.Range(-1, -8);
        z = Random.Range(5, -5);
        return new Vector3(x, y, z);
    }


    // Start is called before the first frame update
    void Start()
    {

        //float trashAmount = Random.Range(10, 20);
        for (int i = 0; i < 0; i++)
        {
            spawnTrash();
            print("Spawned " + 100 + "trash");
        }

        for (int i = 0; i < 50; i++)
        {
            spawnJewelery();
            print("Spawned " + 50 + "jewelery");
        }
    }

    void spawnTrash()
    {
        Instantiate(burkPrefab, trashRandomPosition(), Quaternion.identity);
        Instantiate(plastPrefab, trashRandomPosition(), Quaternion.identity);
        Instantiate(trashPrefab, trashRandomPosition(), Quaternion.identity);
    }

    void spawnJewelery()
    {
        Instantiate(ringPrefab, jeweleryRandomPosition(), Quaternion.identity);
        Instantiate(necklaceGreenPrefab, jeweleryRandomPosition(), Quaternion.identity);
        Instantiate(necklaceRedPrefab, jeweleryRandomPosition(), Quaternion.identity);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
