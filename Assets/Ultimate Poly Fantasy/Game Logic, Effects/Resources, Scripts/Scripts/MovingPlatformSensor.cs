using System.Collections;

using UnityEngine;

namespace AquariusMax.Demo
{
public class MovingPlatformSensor : MonoBehaviour {

    [HideInInspector] public MovingPlatformController gravityLi;


    public void OnTriggerEnter(Collider ob)
    {
        Rigidbody rb = ob.GetComponent<Rigidbody>();
        if(rb != null && rb != gravityLi._rigidbody)
        {
            gravityLi.Add(rb);
        }
    }

    public void OnTriggerExit(Collider ob)
    {
        Rigidbody rb = ob.GetComponent<Rigidbody>();
        if (rb != null && rb != gravityLi._rigidbody)
        {
            gravityLi.Remove(rb);
        }
    }
}
}
