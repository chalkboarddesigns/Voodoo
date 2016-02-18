using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(ArrowController1))]
public class Player : MonoBehaviour
{

    public int maxlives = 5;
    public int curLives = 3;

    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
    ArrowController1 arrowcontroller;


    void Start()
    {
        controller = GetComponent<PlayerController>();
        arrowcontroller = GetComponent<ArrowController1>();
        viewCamera = Camera.main;
        curLives = 3;
    }


    void Update()
    {
        // movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);


        //look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //   Debug.DrawLine(ray.origin, point, Color.blue); 
            controller.LookAt(point);
        }


        //weapon input
        /*   if (Input.GetMouseButtonUp(0))
           {

               ArrowController1.Shoot();
           }

       }
       */

        /*void OnCollisionEnter(Collision _Arrow)
        {

            if (_Arrow.gameObject.tag == "Arrow")
            {
                curLives = curLives - 1;


            }
        }
       */
    }
}
