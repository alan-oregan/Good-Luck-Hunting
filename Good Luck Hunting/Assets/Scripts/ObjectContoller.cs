using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContoller : MonoBehaviour
{
    public float objectSpeed = 10;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDestroy() {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.down * Time.deltaTime * objectSpeed);
    }
}
