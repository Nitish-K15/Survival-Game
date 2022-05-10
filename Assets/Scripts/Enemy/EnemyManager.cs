using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool isPerformingAction;
    EnemyLocomotionManager enemyLocomotion;
    EnemyAnimatorManager enemyAnimatorManager;

    public CharacterStats characterStats;
    public CharacterStats currentTarget;

    EnemyStats enemyStats;
    public State currentState;

    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50;
    public float maximumDetectionAngle = 50;
    // Start is called before the first frame update
    void Start()
    {
        enemyLocomotion = GetComponent<EnemyLocomotionManager>();
        enemyStats = GetComponent<EnemyStats>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        HandleStateMachine();
    }
    private void HandleStateMachine()
    {
        if(currentState != null)
        {
            State nextstate = currentState.Tick(this, enemyStats, enemyAnimatorManager);
            if(nextstate!=null)
            {
                SwitchToNextState(nextstate);
            }
        }

    }

    private void SwitchToNextState(State state)
    {
        currentState = state;
    }
}
