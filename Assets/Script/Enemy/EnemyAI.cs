using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    private enum EnemyState
    {
        Idle,
        Roaming,
        Attack
    }
    private string RAT_RUNNING = "Rat_Run";
    private string RAT_IDLE = "Rat_Idle";
    private string RAT_ATTACK = "Rat_Attack";
    private Vector3 startedPos;
    private Vector3 targetPosition;
    private Vector3 randDir;


    private EnemyState currentState;
    private EnemyMovement enemyMovement;
    private EnemyState CurrentState
    {
        get => currentState;
        set
        {
            if (value == currentState) return;
            currentState = value;
            OnStateChanged();
        }
    }

    [SerializeField] public float maxRoamingRange;
    [SerializeField] public Animator animator;
    private bool isFlip;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }
    private void Start()
    {
        startedPos = transform.position;
        CurrentState = EnemyState.Roaming;


    }
    private void OnStateChanged()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                animator.Play(RAT_RUNNING);

                break;
            case EnemyState.Roaming:
                InitRandRoaming();
                animator.Play(RAT_RUNNING);
                break;
            case EnemyState.Attack:
                break;
        }
    }
    private void FixedUpdate()
    {
        if (CurrentState == EnemyState.Roaming)
        {
            Roaming();
            return;
        }

    }
    private void Roaming()
    {

        enemyMovement.MoveToDir(randDir);
        if (Vector3.Distance(transform.position, targetPosition) <= 1f || Vector3.Distance(transform.position, startedPos) >= maxRoamingRange)
        {
            // reach rand roaming pos 
            //if this object reach the randPos or move pass the maxRoamingRange then
            //cal rand roaming pos again
            InitRandRoaming();
        }


    }
    void InitRandRoaming()
    {
        targetPosition = GetRoamingPosition();
        randDir = (targetPosition - transform.position).normalized;
    }
    Vector3 GetRoamingPosition()
    {
        // get rand roaming pos reletive to the started pos of the oject
        float rand = UnityEngine.Random.Range(1f, maxRoamingRange);
        Vector3 vector3 = startedPos + GetRandomDirection() * rand;
        return vector3;
    }
    Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized;
    }
    private void OnDrawGizmos()
    {

        if (!GameManager.Instance.DEBUG) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startedPos, targetPosition);
        Gizmos.DrawLine(transform.position, startedPos);
        Gizmos.DrawLine(startedPos, (transform.position - startedPos).normalized * maxRoamingRange);


    }

}
