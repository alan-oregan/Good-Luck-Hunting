using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0) {
            Destroy(this.gameObject);
        }
    }
}
