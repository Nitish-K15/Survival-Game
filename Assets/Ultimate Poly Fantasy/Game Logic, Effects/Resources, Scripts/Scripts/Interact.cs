using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
    public class Interact : MonoBehaviour
    {
        [SerializeField]
        float interactionDistance = 3f;

        [SerializeField]
        float interactionSize = 1.0f;

        GameObject focusedObject;

        Vector3 hitPoint = Vector3.zero;

        private void OnDrawGizmos()
        {
            if(hitPoint != Vector3.zero)
            {
                Gizmos.DrawWireSphere(hitPoint, interactionSize);
            }
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            hitPoint = Vector3.zero;

            Vector3 forward = transform.TransformDirection(Vector3.forward) * interactionDistance;
            Debug.DrawRay(transform.position, forward, Color.green);

            Interactable interactable = null;

            // first try the raycast
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                // we put this on the camera, TODO: make generic? we don't want to hit ourselves...
                if (hit.collider != gameObject.GetComponentInParent<Collider>())
                {
                    hitPoint = hit.point;

                    interactable = hit.collider.gameObject.GetComponent<Interactable>();

                    // if we directly hit an interactable object with ray we're good for now...

                    if (interactable == null)
                    {
                        // so try an overlap sphere to see if we just hit a table or something
                        // see if there are any interactables nearby so that the player doesn't have to be as precise
                        Collider[] hitColliders = Physics.OverlapSphere(hit.point, interactionSize);
                        int i = 0;
                        float closest = 999f;
                        while (i < hitColliders.Length)
                        {
                            var nearbyInteractable = hitColliders[i].gameObject.GetComponent<Interactable>();
                            if (nearbyInteractable != null)
                            {
                                var distance = Vector3.Distance(hitColliders[i].ClosestPoint(hit.point), hit.point);
                                if (distance < closest) {
                                    closest = distance;
                                    interactable = nearbyInteractable;
                                }                                
                            }

                            i++;
                        }
                    }
                }
            }

            // TODO: if I don't hit anything with a raycast, do a overlap sphere at the end of the raycast
            // so that I can catch any floating objects

            if (interactable != null)
            {
                if (interactable.gameObject != focusedObject)
                {
                    if (focusedObject != null)
                    {
                        // we hit a different interactable
                        LoseFocus();
                    }

                    focusedObject = interactable.gameObject;
                    interactable.OnFocus();
                }
            }
            else
            {
                LoseFocus();
            }

            // handle interaction
            if (focusedObject != null && Input.GetKeyDown(KeyCode.E))
            {
                focusedObject.GetComponent<Interactable>().OnInteract();
            }
        }

        void LoseFocus()
        {
            if (focusedObject != null)
            {
                Interactable interactable = focusedObject.GetComponent<Interactable>();
                interactable.OnBlur();
                focusedObject = null;
            }
        }
    }
}