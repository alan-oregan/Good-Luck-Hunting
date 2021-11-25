using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Create GameObject SpawnManager
    public GameObject[] duckPrefabs = new GameObject[3];
    private float spawnRangeZHigher = 20;
    private float spawnRangeZLower = 10;
    private float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnTarget(){
        while(true){
            yield return new WaitForSeconds(spawnInterval);
            if (GameManager.isGameActive()) {
                int index = Random.Range(0, duckPrefabs.Length);
                Vector3 spawnPos = new Vector3(-25, Random.Range(1, 4), Random.Range(spawnRangeZLower, spawnRangeZHigher));
                Instantiate(duckPrefabs[index], spawnPos, duckPrefabs[index].transform.rotation);
            }
        }
    }
}
