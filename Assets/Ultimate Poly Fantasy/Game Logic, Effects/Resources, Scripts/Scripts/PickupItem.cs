using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
    public class PickupItem : MonoBehaviour
    {
        [SerializeField]
        float pickupDistance = 3f;

        GameObject carriedItem;
        GameObject hand;

        private void Start()
        {
            hand = new GameObject("CarryHand");
            hand.transform.parent = transform;
            hand.transform.localPosition = new Vector3(0f, 0f, pickupDistance);

            Rigidbody body = hand.AddComponent<Rigidbody>();
            body.isKinematic = true;
        }

        public void Pickup(GameObject item)
        {
            if (carriedItem != null) { return; }

            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb != null)
            {
                FixedJoint joint = hand.AddComponent<FixedJoint>();
                joint.enableCollision = false;
                joint.connectedBody = rb;
            }

            Interactable interactable = item.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.OnBlur();
                interactable.enabled = false;
            }

            // ignore raycast while in your face
            item.layer = 2;

            carriedItem = item;
        }

        public void Drop()
        {
            if (carriedItem == null) { return; }

            var joint = hand.GetComponent<FixedJoint>();
            joint.connectedBody.angularDrag = 0.05f;
            joint.connectedBody = null;
            Destroy(joint);

            Interactable interactable = carriedItem.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.enabled = true;
            }

            // TODO: restore original layer instead of assuming default?
            carriedItem.layer = 0;

            carriedItem = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Drop();
            }
        }
    }
}
