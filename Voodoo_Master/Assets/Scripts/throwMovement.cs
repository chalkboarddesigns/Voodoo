using UnityEngine;
using System.Collections;

public class throwMovement : MonoBehaviour
{
    public GameObject arrow;
    GameObject heldArrow;
    Vector3 originalHandPos;

    void Start()
    {
        originalHandPos = transform.localPosition;
    }

    void Update()
    {
        // Create temporary arrow in hand when button is presses
        if (Input.GetMouseButtonDown(0))
        {
            heldArrow = Instantiate(arrow, transform.localPosition, transform.rotation) as GameObject;
        }
        // as the button is pressed and held, hand with arrow retracts
        if (Input.GetMouseButton(0))
        {
            transform.localPosition -= new Vector3(0.0f, 0.002f, 0.01f);
            // if player is facing a new direction, update arrow direction            
            heldArrow.transform.position = transform.position;
            heldArrow.transform.rotation = transform.rotation;
        }
        // if the fire button is released, return hand to original position and destroy the temporary arrow
        if(Input.GetMouseButtonUp(0))
        {
            transform.localPosition = originalHandPos;
            Destroy(heldArrow);
        }       
    }
}
