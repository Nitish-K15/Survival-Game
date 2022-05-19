using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
    [RequireComponent(typeof(Animator))]
    public class TwoStateToggle : MonoBehaviour
    {

        public bool isOpen = true;

        Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            bool currentState = anim.GetBool("isOpen");

            if (currentState != isOpen)
            {
                anim.SetBool("isOpen", isOpen);
            }
        }

        public void Activate()
        {
            anim.SetTrigger("activate");

            isOpen = !isOpen;
        }
    }
}