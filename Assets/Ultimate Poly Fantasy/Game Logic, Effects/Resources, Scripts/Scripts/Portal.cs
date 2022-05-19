using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.Demo
{
public class Portal : MonoBehaviour {



    [SerializeField]
    public Transform PortalEndPoint;

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = PortalEndPoint.position;
    }

}
}
