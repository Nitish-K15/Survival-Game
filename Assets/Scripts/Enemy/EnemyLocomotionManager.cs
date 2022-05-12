using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;




    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
    }

    private void Start()
    {

    }



    public void HandleMoveToTarget()
    {
       
    }

    //private void HandleRotateTowardsTarget()
    //{
    //    if(enemyManager.isPerformingAction)
    //    {
    //        Vector3 direction = currentTarget.transform.position - transform.position;
    //        direction.y = 0;
    //        direction.Normalize();

    //        if(direction == Vector3.zero)
    //        {
    //            direction = transform.forward;
    //        }

    //        Quaternion targetRotation = Quaternion.LookRotation(direction);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed / Time.deltaTime);
    //    }

    //    else
    //    {
    //        Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity);
    //        Vector3 targetVelocity = enemyRigidbody.velocity;

    //        navMeshAgent.enabled = true;
    //        navMeshAgent.SetDestination(currentTarget.transform.position);
    //        enemyRigidbody.velocity = targetVelocity;
    //        transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);
    //    }

    //}
}
