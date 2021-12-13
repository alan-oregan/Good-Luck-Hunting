using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{

    // Game Objects
    public GameObject projectilePrefab;
    public Transform LaunchPoint;
    private GameManager gameManager;

    // Variables
    private AudioSource cannonAudio;
    public AudioClip shootSound;
    public int ammoCount;
    public float movementSpeed = 5.0f;
    public float projectileForce = 25;
    private float verticalRotation;
    private float horizontalRotation;

    void projectileLogic() {

        // On spacebar press or primary mouse button, shoot the projectile
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (gameManager.UI.getAmmo() > 0)
            {
                // Play Cannon shot sound
                cannonAudio.PlayOneShot(shootSound, .1f);

                // Create the projectile at the tip of the launcher
                GameObject projectile = Instantiate(projectilePrefab, LaunchPoint.position, LaunchPoint.localRotation);

                Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();

                transform.rotation = LaunchPoint.transform.rotation;

                // Put force on the projectile at instantiation
                projectileRigidBody.velocity = transform.up * projectileForce;

                //reduce ammo by one
                gameManager.UI.UpdateAmmo(-1);

                CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .5f);
            }
        }
    }

    // Moving the launcher
    void movementLogic() {

        // rotating the launcher vertically and horizontally with mouse and keyboard input

        float horizontalKeyboardInput = Input.GetAxis("Vertical") * movementSpeed;
        float verticalKeyboardInput = Input.GetAxis("Horizontal") * movementSpeed;

        float horizontalMouseInput = Input.GetAxis("Mouse Y") * movementSpeed;
        float verticalMouseInput = Input.GetAxis("Mouse X") * movementSpeed;

        verticalRotation += verticalMouseInput;
        verticalRotation += verticalKeyboardInput;
        verticalRotation = Mathf.Clamp(verticalRotation, 40f, 140f);

        horizontalRotation -= horizontalMouseInput;
        horizontalRotation -= horizontalKeyboardInput;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -45f, 0f);

        transform.localRotation =  Quaternion.Euler(0f, verticalRotation, horizontalRotation);

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
        // Cannon audio
        cannonAudio = GetComponent<AudioSource>();

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
