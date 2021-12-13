using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class DetectCollisions : MonoBehaviour
{
    public int pointValue = 1;
    public int ammoValue = 2;

    public ParticleSystem explosionParticle;

    private AudioSource audioSource;
    public AudioClip hitSound;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        audioSource.clip = hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("WhiteDuck"))
        {
            Destroy(other.gameObject);
            gameManager.UI.UpdateScore(pointValue);
            gameManager.UI.UpdateAmmo(ammoValue);
        }
        
        if (other.gameObject.CompareTag("OrangeDuck"))
        {
            Destroy(other.gameObject);
            gameManager.UI.UpdateScore(pointValue*2);
            gameManager.UI.UpdateAmmo(ammoValue*2);
        }
        
        if (other.gameObject.CompareTag("PondDuck"))
        {
            Destroy(other.gameObject);
            gameManager.UI.UpdateScore(pointValue*3);
            gameManager.UI.UpdateAmmo(ammoValue*3);
        }

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        explosionParticle.Play();
        CameraShaker.Instance.ShakeOnce(1f, 1f, .1f, .5f);
        audioSource.Play();

        Destroy(gameObject);
    }
}
