using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{

    public float velocity = 1;

    public void SetSpeed(float newSpeed)
    {
        velocity = newSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocity);
    }

}
