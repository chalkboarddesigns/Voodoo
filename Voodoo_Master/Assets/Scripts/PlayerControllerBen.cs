using UnityEngine;
using System.Collections;

public class PlayerControllerBen : MonoBehaviour
{
    Rigidbody player;
    public GameObject arrow, arrowClone;
    public Transform arrowSpawn;
    public float currShootForce, speed;
    public float chargeSpeed = 100f, minShootForce = 100f, maxShootForce = 500f;
    private bool fired;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // If the max force has been exceeded and the arrow hasn't yet been launched..
        if (currShootForce >= maxShootForce && !fired)
        {
            // ...use the max force and shoot the arrow.
            currShootForce = maxShootForce;
            ShootArrow();
        }
        // Otherwise, if the fire button has just started being pressed...
        else if (Input.GetMouseButtonDown(0))
        {
            // ...reset the fired flag and reset the shoot force.
            fired = false;
            currShootForce = minShootForce;
        }
        // Otherwise, if the fire button is being held and the arrow hasn't been launched yet...
        else if (Input.GetMouseButton(0) && !fired)
        {
            // Increment the shoot force
            currShootForce += chargeSpeed * Time.deltaTime;
        }
        // Otherwise, if the fire button is released and the shell hasn't been launched yet...
        else if (Input.GetMouseButtonUp(0) && !fired)
        {
            // ...launch the arrow
            ShootArrow();
        }
        if (Input.GetMouseButton(1) && fired)
        {
            RetractArrow();
        }
    }

    void FixedUpdate()
    {
        PlayerMover();
    }

    void PlayerMover()
    {
        // Get up/down/left/right input
        float moveXAxis = Input.GetAxis("Horizontal");
        float moveZAxis = Input.GetAxis("Vertical");
        // Use input to create movement vector
        Vector3 movement = new Vector3(moveXAxis, 0.0f, moveZAxis);
        // If not at rest, player faces the direction of movement
        if (movement.magnitude != 0)
        {
            transform.forward = movement;         
        }
        // Player moves in direction at speed
        player.velocity = movement * speed;       
    }

    void ShootArrow()
    {
        // Set the fired flag so ShootArrow is only called once.
        fired = true;
        // Create an instance of the arrow and store a reference to it's rigidbody.
        arrowClone = Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation) as GameObject;
        // Apply firing force to the arrow in the player's forward direction
        arrowClone.GetComponent<Rigidbody>().AddForce(currShootForce * transform.forward);
        // If you want the arrow to ignore gravity (can be changed)
        arrowClone.GetComponent<Rigidbody>().useGravity = false;
        // Reset the shoot force
        currShootForce = minShootForce;        
    }

    void RetractArrow()
    {
        // Get the distance between the fired arrow and the player
        Vector3 seperation = arrowClone.transform.position - transform.position;
        // Move the arrow back towards the player
        arrowClone.GetComponent<Rigidbody>().velocity *= 0.0f;
        arrowClone.transform.position -= seperation.normalized;
        // When the arrow is back to the player, destroy the clone and reset the fired flag
        if(arrowClone.transform.position.z - transform.position.z < 1.0f)
        {
            Destroy(arrowClone);
            fired = false;
        }
    }
}
