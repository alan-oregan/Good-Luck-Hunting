using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Create GameObject SpawnManager
    public GameObject[] duckPrefabs = new GameObject[3];
    public float spawnRangeZHigher = 10;
    public float spawnRangeZLower = 5;
    public float spawnInterval = 1.5f;


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
            yield return new WaitForSeconds(Random.Range(.5f, spawnInterval));
            if (GameManager.isGameActive()) {

                int index = Random.Range(0, duckPrefabs.Length);

                Vector3 spawnPos = new Vector3(0, 0, 0);

                if(index == 0){
                    // White Duck
                    spawnPos = new Vector3(-25, Random.Range(3, 6), Random.Range(spawnRangeZLower, spawnRangeZHigher));
                }
                else if(index == 1){
                    // Orange Duck
                    spawnPos = new Vector3(-25, Random.Range(3, 6), Random.Range(spawnRangeZLower, spawnRangeZHigher));
                }
                else if(index == 2){
                    // Pond Duck
                    spawnPos = new Vector3(-25, Random.Range(3, 6), Random.Range(spawnRangeZLower, spawnRangeZHigher));
                }

                //Vector3 spawnPos = new Vector3(-25, Random.Range(3, 6), Random.Range(spawnRangeZLower, spawnRangeZHigher));
                Instantiate(duckPrefabs[index], spawnPos, duckPrefabs[index].transform.rotation);
            }
        }
    }
}
