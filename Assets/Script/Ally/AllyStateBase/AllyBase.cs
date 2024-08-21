using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AllyBase : MonoBehaviour, ITriggerCheck, IHandleAttack, IMoveAle
{
    // Start is called before the first frame update
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;
    public float speed { get; set; }
    public bool isArgo { get; set; }
    public bool isAttackWithInRange { get; set; }
    public bool isAttackWithInLongRange { get; set; }
    public Animator animator { get; set; }
    public Transform target;

    [SerializeField] private AllyIdleStateSOBase allyIdleStateSOBase;
    [SerializeField] private AllyAttackSOBase allyAttackSOBase;


    public AllyIdleStateSOBase AllyIdleStateSOBase;
    public AllyAttackSOBase AllyAttackSOBase;

    public StateMachineBase stateMachine;
    public AllyIdleState allyIdleState;
    public AllyAttackBase allyAttackState;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        stateMachine = new StateMachineBase();

        AllyIdleStateSOBase = Instantiate(allyIdleStateSOBase);
        AllyAttackSOBase = Instantiate(allyAttackSOBase);

        allyIdleState = new AllyIdleState(stateMachine, this);
        allyAttackState = new AllyAttackBase(stateMachine, this);
        RB = GetComponent<Rigidbody2D>();
        


        AllyIdleStateSOBase.Init(this, transform, gameObject);
        AllyAttackSOBase.Init(this, transform, gameObject);




       

    }
    public void Update(){
        stateMachine.CurrentState.FrameUpdate();
    }
    public void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicUpdate();
    }
   private void Start() {
    stateMachine.Init(allyIdleState);
   }
    public virtual void CheckForFaceDir(Vector2 dir)
    {

    }

    public void HandleAttack()
    {

    }

    public void setAttackWithInLongRange(bool isAttackWithInLongRange)
    {
        this.isAttackWithInLongRange = isAttackWithInLongRange;
    }

    public void setAttackWithInRange(bool isAttackWithInRange)
    {
        this.isAttackWithInRange = isAttackWithInRange;
    }

    public void setIsArgo(bool isArgo)
    {
        this.isArgo = isArgo;
    }
    protected virtual void SetTarget(Transform target)
    {

    }

    public void MoveEnemy(Vector2 dir)
    {

    }
}
