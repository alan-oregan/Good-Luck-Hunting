using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int pointValue = 1;
    public int ammoValue = 2;

    public ParticleSystem explosionParticle;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PondDuck"))
        {
            Destroy(other.gameObject);
            gameManager.UI.UpdateScore(pointValue * 3);
            gameManager.UI.UpdateAmmo(ammoValue * 2);
        }

        if (other.gameObject.CompareTag("OrangeDuck"))
        {
            Destroy(other.gameObject);
            gameManager.UI.UpdateScore(pointValue * 2);
            gameManager.UI.UpdateAmmo(ammoValue * 2);
        }

        if (other.gameObject.CompareTag("WhiteDuck"))
        {
            Destroy(other.gameObject);
            gameManager.UI.UpdateScore(pointValue);
            gameManager.UI.UpdateAmmo(ammoValue);
        }

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        explosionParticle.Play();
        

        Destroy(gameObject);
    }
}
