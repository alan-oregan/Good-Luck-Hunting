using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

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
        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
            gameManager.UI.UpdateScore(1);
        }
        Destroy(gameObject);
    }
}
