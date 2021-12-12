using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Game Objects
    public GameObject projectilePrefab;
    public Transform LaunchPoint;
    private GameManager gameManager;

    // Variables
    public int ammoCount;
    public float movementSpeed = 5.0f;
    private float verticalMouseRotation;
    private float horizontalMouseRotation;

    void projectileLogic() {

        // On spacebar press or primary mouse button, shoot the projectile
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (gameManager.UI.getAmmo() > 0)
            {
                // Create the projectile at the tip of the launcher
                Instantiate(projectilePrefab, LaunchPoint.position, LaunchPoint.localRotation);

                // reduce ammo by one
                gameManager.UI.UpdateAmmo(-1);
            }
        }
    }

    // Moving the launcher
    void movementLogic() {
        // Move the launcher horizontally with keyboard input
        // relative to the worlds rotation so that the local rotation of the mouse doesnt affect it
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * movementSpeed, Space.World);

        // rotating the launcher vertically and horizontally with mouse input
        float horizontalMouseInput = Input.GetAxis("Mouse Y") * movementSpeed;
        float verticalMouseInput = Input.GetAxis("Mouse X") * movementSpeed;

        verticalMouseRotation -= verticalMouseInput;
        verticalMouseRotation = Mathf.Clamp(verticalMouseRotation, 0f, 180f); // sets rotation limits in degrees

        horizontalMouseRotation += horizontalMouseInput;
        horizontalMouseRotation = Mathf.Clamp(horizontalMouseRotation, -90f, 0f); // sets rotation limits in degrees

        transform.localRotation =  Quaternion.Euler(0f, verticalMouseRotation, horizontalMouseRotation); // set axis rotation

        // Logging
        //Debug.Log(horizontalMouseRotation + "X " + verticalMouseRotation + "Y");
    }

    public void updateAmmo(){

        //decrease ammo and display to text on screen
        ammoCount -= 1;
        //ammoText.text = "Ammo " + ammoCount;

    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // calling logic methods while game is active
        if (GameManager.isGameActive()) {
            movementLogic();
            projectileLogic();
        }
    }
}
