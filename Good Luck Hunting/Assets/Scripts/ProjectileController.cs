using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Variables
    public float projectileForce = 25;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        // Put force on the projectile at instantiation
        playerRb.AddForce(transform.forward * (projectileForce * 0.7f), ForceMode.Impulse);
        playerRb.AddForce(transform.up * (projectileForce), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0) {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy() {
        //Debug.Log("add explosion effects");
    }
}
