using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : AnimatorManager
{
    public EnemyManager enemyManager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorMove()
    {
        float delta = Time.deltaTime;
        //enemyManager.enemyRigidbody.drag = 0;
        Vector3 deltaPosition = anim.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        //enemyManager.enemyRigidbody.velocity = velocity;
    }
}
