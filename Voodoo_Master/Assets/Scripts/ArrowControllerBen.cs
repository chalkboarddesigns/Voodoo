using UnityEngine;
using System.Collections;

public class ArrowControllerBen : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowSpawn;
    float shootForce = 10f;

    public void ShootArrow()
    {
        if (Input.GetButtonUp("Fire1") == true)
        {
            GameObject arrowClone = Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation) as GameObject;
            arrowClone.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }
    }
}
