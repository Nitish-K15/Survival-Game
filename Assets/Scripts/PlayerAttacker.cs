using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HandleLightAttack()
    {
        
    }
    public void HandleHeavyAttack()
    {

    }
}
