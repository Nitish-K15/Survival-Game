using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool isPerformingAction;
    EnemyAnimatorManager enemyAnimatorManager;

    public CharacterStats characterStats;
    public CharacterStats currentTarget;

    EnemyStats enemyStats;
    public State currentState;
    public NavMeshAgent navMeshAgent;
    //public Rigidbody enemyRigidbody;

    public float distanceFromTarget;
    public float rotationSpeed = 15;

    public float maximumAttackRange = 1.5f;

    public float currentRecoveryTime = 0;

    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50;
    public float maximumDetectionAngle = 50;
    public float viewableAngle;
    // Start is called before the first frame update
    void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
       // enemyRigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        navMeshAgent.enabled = false;
        //enemyRigidbody.isKinematic = false;
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
