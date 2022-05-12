using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public CombatStanceState combatStanceState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentattack;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
        if (enemyManager.isPerformingAction)
            return combatStanceState; 

        if(currentattack != null)
        {
            if(enemyManager.distanceFromTarget < currentattack.minimumDistanceNeededToAttack)
            {
                return this;
            }
            else if(enemyManager.distanceFromTarget < currentattack.MaximumDistanceNeededToAttack)
            {
                if(viewableAngle <= currentattack.maximumAtackAngle && viewableAngle >= currentattack.minimumAttackAngle)
                {
                    if(enemyManager.currentRecoveryTime <= 0 && enemyManager.isPerformingAction == false)
                    {
                        enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                        enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
                        enemyAnimatorManager.PlayTargetAnimation(currentattack.attackAnimation, true);
                        enemyManager.isPerformingAction = true;
                        enemyManager.currentRecoveryTime = currentattack.recoveryTime;
                        currentattack = null;
                        return combatStanceState;
                    }
                }
            }
        }
        else
        {
            GetNewAttack(enemyManager);
        }

        return combatStanceState; 

    }

    private void GetNewAttack(EnemyManager enemyManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

        int maxScore = 0;

        for(int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if(enemyManager.distanceFromTarget <= enemyAttackAction.MaximumDistanceNeededToAttack && enemyManager.distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
            {
                if(viewableAngle <= enemyAttackAction.maximumAtackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    maxScore += enemyAttackAction.attackScore;
                }
            }
        }

        int randomValue = Random.Range(0, maxScore);
        int temporaryScore = 0;

        for(int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if(enemyManager.distanceFromTarget <= enemyAttackAction.MaximumDistanceNeededToAttack && enemyManager.distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
            {
                if (currentattack != null)
                    return;
                temporaryScore += enemyAttackAction.attackScore;

                if(temporaryScore > randomValue)
                {
                    currentattack = enemyAttackAction; 
                }
            }
        }
    }
}
