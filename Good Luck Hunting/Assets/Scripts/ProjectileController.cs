using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Variables
    public float projectileForce = 25;
    private Rigidbody projectileRigidBody;
    private GameObject launchPoint;

    // Start is called before the first frame update
    void Start()
    {
        projectileRigidBody = GetComponent<Rigidbody>();

        launchPoint = GameObject.FindGameObjectWithTag("LaunchPoint");

        transform.rotation = launchPoint.transform.rotation;

        // Put force on the projectile at instantiation
        projectileRigidBody.velocity = transform.up * projectileForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0) {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy() {
        
        Debug.Log("Boom");
    }
}
