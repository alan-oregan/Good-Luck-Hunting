using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float xRange = 2.5f;

    // Update is called once per frame
    void Update()
    {
        // check left side
        if(transform.position.x < -xRange){

            transform.position = new Vector3(- xRange, transform.position.y, transform.position.z);
        }

        // check right side
        if(transform.position.x > xRange){

            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
