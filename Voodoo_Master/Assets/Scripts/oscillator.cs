using UnityEngine;
using System.Collections;

public class oscillator : MonoBehaviour
{
    public GameObject Leg1;
    public GameObject Leg2;

    void Update()
    {
        float motionBody = Mathf.Sin(Time.time * 5) * 0.002f;
        float motionLeg1 = Mathf.Sin(Time.time * 10) * 0.01f;
        float motionLeg2 = -motionLeg1;

        transform.position = new Vector3(transform.position.x, transform.position.y + motionBody, transform.position.z);

        Leg1.transform.position = new Vector3(Leg1.transform.position.x, Leg1.transform.position.y + motionLeg1 - motionBody, Leg1.transform.position.z);
        Leg2.transform.position = new Vector3(Leg2.transform.position.x, Leg2.transform.position.y + motionLeg2 - motionBody, Leg2.transform.position.z);
    }
}
