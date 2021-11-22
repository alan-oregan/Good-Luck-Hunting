using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Create GameObject SpawnManager
    public GameObject[] duckPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 2;

    private float spawnInterval = 1.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnDuck", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.S)){
        //     // Randomly Generate duck and spawn pos
        //     SpawnDuck();
        // }   
    }

    void SpawnDuck(){
        int duckIndex = Random.Range(0, duckPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(duckPrefabs[duckIndex], new Vector3(0, 0, 20), duckPrefabs[duckIndex].transform.rotation);
    }
}
