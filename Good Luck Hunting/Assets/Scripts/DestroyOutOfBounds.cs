using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    // Variables
    private float leftBound = -15f;
    private float rightBound = 15f;

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
