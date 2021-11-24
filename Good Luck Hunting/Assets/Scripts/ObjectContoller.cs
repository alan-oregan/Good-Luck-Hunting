using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContoller : MonoBehaviour
{
    public float objectSpeed = 10;

    public GameManager gameManager;

    public int pointValue = 10;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnDestroy() {
        // Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.right * Time.deltaTime * objectSpeed);
    }
}
