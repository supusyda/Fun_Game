using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    private enum EnemyState
    {
        Idle,
        Roaming,
        Attack,
        GetHit,
        Die
    }
    private string RAT_RUNNING = "Rat_Run";
    private string RAT_IDLE = "Rat_Idle";
    private string RAT_ATTACK = "Rat_Attack";
    private string RAT_GET_HIT = "Rat_GetHit";

    private Vector3 startedPos;
    private Vector3 targetPosition;
    private Vector3 randDir;
    private Collider2D enemyColider;


    private EnemyState currentState;
    private bool _isInvincible = false;
    private bool isInvincible
    {
        get => _isInvincible; set
        {
            _isInvincible = value;
            enemyColider.enabled = !value;

        }
    }


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
        enemyColider = GetComponent<Collider2D>();
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
                animator.CrossFade(RAT_IDLE, 0, 0);

                break;
            case EnemyState.Roaming:
                InitRandRoaming();
                animator.CrossFade(RAT_RUNNING, 0, 0);
                break;
            case EnemyState.Attack:
                break;
            case EnemyState.GetHit:
                animator.CrossFade(RAT_GET_HIT, 0, 0);
                break;
            case EnemyState.Die:

                break;
            default:
                break;
        }
    }
    private void FixedUpdate()
    {
        if (CurrentState == EnemyState.Die) return;

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
    public void onGettingHit()
    {
        CurrentState = EnemyState.GetHit;
        this.isInvincible = true;
        StartCoroutine(onFinishGetingHit(animator.GetCurrentAnimatorStateInfo(0).length));

    }
    IEnumerator onFinishGetingHit(float timeAnimationPlay)
    {
        yield return new WaitForSeconds(timeAnimationPlay);

        CurrentState = EnemyState.Roaming;
        this.isInvincible = false;
    }
    private void OnDrawGizmos()
    {

        // if (!GameManager.Instance.DEBUG) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startedPos, targetPosition);
        Gizmos.DrawLine(transform.position, startedPos);
        Gizmos.DrawLine(startedPos, (transform.position - startedPos).normalized * maxRoamingRange);


    }
    public void SetStateToDie()
    {
        currentState = EnemyState.Die;
        transform.GetComponent<Collider2D>().enabled = false;
    }

}
