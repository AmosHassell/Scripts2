using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    //This is for trying to make the animals spawn on the left, right, and top side of the screen
    private string[] directions = { "top", "left", "right" };
    // Start is called before the first frame update
    void Start()
    {
        //Allows the repetition of animals spawning
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }
    // Update is called once per frame
    void Update()
    {

    }
    //Spawns the animals at random locations within certain values
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        string spawnDirection = directions[Random.Range(0, directions.Length)];
        Vector3 spawnPos = Vector3.zero;
        switch (spawnDirection)
        {
            // Quaternion apparently changes the rotation of an object.
            case "left":
                spawnPos = new Vector3(-30, 0, Random.Range(-2, 17));
                Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.LookRotation(Vector3.right));
                break;
                //Break gets rid of the closest surrounding iteration statement.
            case "right":
                spawnPos = new Vector3(30, 0, Random.Range(-2, 17));
                Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.LookRotation(Vector3.left));
                break;
            default:
                spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
               
                Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
                break;
        }

    }
}
