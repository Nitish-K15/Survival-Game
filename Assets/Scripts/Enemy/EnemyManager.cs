using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool isPerformingAction;
    EnemyLocomotionManager enemyLocomotion;

    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50;
    public float maximumDetectionAngle = 50;
    // Start is called before the first frame update
    void Start()
    {
        enemyLocomotion = GetComponent<EnemyLocomotionManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        HandleCurrentAction();
    }
    private void HandleCurrentAction()
    {
        if(enemyLocomotion.currentTarget == null)
        {
            enemyLocomotion.HandleDetection();
        }
        else
        {
            enemyLocomotion.HandleMoveToTarget();
        }
    }
}
