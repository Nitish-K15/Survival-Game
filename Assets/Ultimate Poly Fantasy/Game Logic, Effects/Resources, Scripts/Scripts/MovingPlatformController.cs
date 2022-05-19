using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
public class MovingPlatformController : MonoBehaviour {

    public bool triggerSensor = false;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    Vector3 lastPosition;
    Transform _transform;
    [HideInInspector] public Rigidbody _rigidbody;


    private void Start()
    {
        _transform = transform;
        lastPosition = _transform.position;
        _rigidbody = GetComponent<Rigidbody>();

        if (triggerSensor)
        {
            foreach (MovingPlatformSensor sensor in GetComponentsInChildren<MovingPlatformSensor>())
            { 
            sensor.gravityLi = this;
            }
        }
    }


    private void LateUpdate()
    {
        if(rigidbodies.Count > 0)
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                Rigidbody rb = rigidbodies[i];
                Vector3 velocity = (_transform.position - lastPosition);
                rb.transform.Translate(velocity, _transform);
            }
        }

        lastPosition = _transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (triggerSensor) return;

        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if(rb != null)
        {
            Add(rb);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (triggerSensor) return;


        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Remove(rb);
        }
    }


    public void Add(Rigidbody rb)
    {
        if (!rigidbodies.Contains(rb))
            rigidbodies.Add(rb);
    }

    public void Remove(Rigidbody rb)
    {
        if (rigidbodies.Contains(rb))
            rigidbodies.Remove(rb);

    }
}
}
