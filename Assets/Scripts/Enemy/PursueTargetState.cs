using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTargetState : State
{
    public CombatStanceState combatStanceState;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (enemyManager.isPerformingAction)
            return this;

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

        if (enemyManager.isPerformingAction)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            enemyManager.navMeshAgent.enabled = false;
        }
        else
        {
            if (enemyManager.distanceFromTarget > enemyManager.maximumAttackRange)
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
            }

        }

        HandleRotateTowardsTarget(enemyManager);

        //avMeshAgent.transform.localPosition = Vector3.zero;
        enemyManager.navMeshAgent.nextPosition = enemyManager.transform.position;
        //navMeshAgent.transform.localRotation = Quaternion.identity;

        if(enemyManager.distanceFromTarget <= enemyManager.maximumAttackRange)
        {
            return combatStanceState;
        }
        else
        {
            return this;
        }
    }

    private void HandleRotateTowardsTarget(EnemyManager enemyManager)
    {
        if (enemyManager.isPerformingAction)
        {
            Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
            StartCoroutine(ResetVariables(enemyManager));
        }

        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(enemyManager.navMeshAgent.desiredVelocity);
            //Vector3 targetVelocity = enemyManager.enemyRigidbody.velocity;

            enemyManager.navMeshAgent.enabled = true;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            //enemyManager.enemyRigidbody.velocity = targetVelocity;
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
        }

    }

    IEnumerator ResetVariables(EnemyManager enemyManager)
    {
        yield return new WaitForSeconds(enemyManager.currentRecoveryTime);
        enemyManager.currentRecoveryTime = 0;
        enemyManager.isPerformingAction = false;
    }
}
