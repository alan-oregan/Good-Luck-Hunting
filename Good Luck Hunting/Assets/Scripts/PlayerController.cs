using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables
    public float speed = 0.5f;
    public GameObject projectilePrefab;
    private float verticalInput;
    private float horizontalInput;

    // offset for tip of launcher relative to launcher
    private Vector3 offset = new Vector3(0, 0.85f, 1);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;

        // Get the user's horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the launcher left and right
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // On spacebar press or primary mouse button, shoot the projectile
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Create the projectile at the tip of the launcher
            Instantiate(projectilePrefab, transform.position + offset, projectilePrefab.transform.rotation);
        }
    }
}
