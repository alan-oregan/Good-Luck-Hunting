using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Variables
    public float projectileSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.left, 50);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }
}
