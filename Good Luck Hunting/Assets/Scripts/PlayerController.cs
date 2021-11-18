using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables
    public float speed = 5.0f;
    public GameObject projectilePrefab;
    public GameObject playerObject;

    private float verticalInput;
    private float horizontalInput;

    // offset for tip of launcher relative to launcher
    private Vector3 offset = new Vector3(0, 0.85f, 1);

    private float mouseRotation;
    public float mouseSpeed = 10f;

    void launchProjectile() {

        // Create the projectile at the tip of the launcher
        Instantiate(projectilePrefab, transform.position + offset, projectilePrefab.transform.rotation);

    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        // Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // aimPos.z = 0;

        // Get the user's horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;

        // // rotate on x axis with mouse
        // mouseRotation = Mathf.Clamp(mouseRotation, -90f, 90f);
        // mouseRotation -= mouseX;

        // transform.Rotate(Vector3.up * mouseX); //rotates around x axis
        // // = Quaternion.Euler(mouseX, 0f, 0f); //rotates around x axis


            float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;

            mouseRotation -= mouseY;

            mouseRotation = Mathf.Clamp(mouseRotation, -90f, 90f); //stops the camera from rotating to far up or down

            // transform.localRotation = Quaternion.Euler(mouseRotation, 0f, 0f); //rotates around y axis
            // transform.localRotation =  Quaternion.Euler(mouseRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseRotation); //rotates around the x axis

            // Debug.Log(mouseX + "X " + mouseY + "Y");
            Debug.Log("Mouse Rotation: " + mouseRotation);

        // Move the launcher left and right
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // On spacebar press or primary mouse button, shoot the projectile
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            launchProjectile();
        }
    }
}
