using UnityEngine;
using System.Collections;

public class ArrowController1 : MonoBehaviour
{

    Arrow equippedArrow;
    public Transform arrowPos;
    public Vector3 _origianlPos;
    public bool canShoot = true;
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    public GameObject FuckingArrow;


    void Start()
    {

    }

    public void FireInstantiate()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);

        bulletClone.velocity = transform.forward * bulletSpeed;



    }

    public void ArrowReturn()
    {
        // Debug.Log("we are here");
        equippedArrow.transform.position = _origianlPos;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            FireInstantiate();
            // Debug.Log("ButtonPressed");
            //canShoot = false;
        }
        if (Input.GetButton("Fire2"))
        {
            // Debug.Log("ButtonPressed");
            ArrowReturn();

        }
    }
}

