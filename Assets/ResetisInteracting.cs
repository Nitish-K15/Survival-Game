using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetisInteracting : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isInteracting", false);
        animator.applyRootMotion = false;
    }
}
