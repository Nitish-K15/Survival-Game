using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
    public class ToggleIsOpenBehavior : StateMachineBehaviour
    {
        // this is so that we don't trip the flag early
        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            bool isOpen = animator.GetBool("isOpen");
            animator.SetBool("isOpen", !isOpen);
        }
    }
}
