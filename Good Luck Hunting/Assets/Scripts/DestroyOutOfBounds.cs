using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    // Variables
    private float leftBound = -25f;
    private float rightBound = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < leftBound){
            Destroy(gameObject);
        }
        else if(transform.position.x > rightBound){
            Destroy(gameObject);
        }
    }
}
