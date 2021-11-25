using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Game Objects
    public GameObject projectilePrefab;
    private GameManager gameManager;

    // Variables
    public float movementSpeed = 5.0f;
    private float verticalInput;
    private float horizontalInput;
    private float verticalMouseRotation;
    private float horizontalMouseRotation;

    // offset for tip of launcher relative to launcher
    private Vector3 offset = new Vector3(0, 0.85f, 1);

    void projectileLogic() {

        // Want to use Raycast https://answers.unity.com/questions/338394/how-can-i-get-the-coordinates-of-the-point-on-an-o.html
        // Used this: https://answers.unity.com/questions/329155/how-to-calculate-position-of-cannons-end.html

        Vector3 localOffset = transform.up * transform.localScale.y / 2 * 2.4f;
        Vector3 pos = transform.position + localOffset; //This is the position

        // On spacebar press or primary mouse button, shoot the projectile
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Create the projectile at the tip of the launcher
            Instantiate(projectilePrefab, pos, transform.localRotation);
        }
    }

    // Moving the launcher
    void movementLogic() {
        // Move the launcher horizontally with keyboard input
        // relative to the worlds rotation so that the local rotation of the mouse doesnt affect it
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * movementSpeed, Space.World);

        // rotating the launcher vertically and horizontally with mouse input
        float horizontalMouseInput = Input.GetAxis("Mouse X") * movementSpeed;
        float verticalMouseInput = Input.GetAxis("Mouse Y") * movementSpeed;

        verticalMouseRotation -= verticalMouseInput;
        verticalMouseRotation = Mathf.Clamp(verticalMouseRotation, 30f, 50f); // sets rotation limits in degrees

        horizontalMouseRotation += horizontalMouseInput;
        horizontalMouseRotation = Mathf.Clamp(horizontalMouseRotation, -40f, 40f); // sets rotation limits in degrees

        transform.localRotation =  Quaternion.Euler(verticalMouseRotation, horizontalMouseRotation, 0f); // set axis rotation

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
    // Logging
    // Debug.Log(horizontalMouseRotation + "X " + verticalMouseRotation + "Y");
    }
}
