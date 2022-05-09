using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager enemyManager;
    public LayerMask detectionLayer;
    CharacterStats characterStats;
    public CharacterStats currentTarget;
    

    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();    
    }

    public void HandleDetection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

        for(int i = 0;i < colliders.Length;i++)
        {
            characterStats = colliders[i].GetComponent<CharacterStats>();

            if(characterStats!=null)
            {
                Vector3 targetDirection = characterStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                if(viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    currentTarget = characterStats;
                }
            }
        }
    }
}
