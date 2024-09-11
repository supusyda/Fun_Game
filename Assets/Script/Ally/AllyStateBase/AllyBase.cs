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
    // public 
    [SerializeField] private AllyIdleStateSOBase allyIdleStateSOBase;
    [SerializeField] private AllyAttackSOBase allyAttackSOBase;


    public AllyIdleStateSOBase AllyIdleStateSOBase;
    public AllyAttackSOBase AllyAttackSOBase;

    public StateMachineBase stateMachine;
    public AllyIdleState allyIdleState;
    public AllyAttackBase allyAttackState;

    virtual protected void Awake()
    {
        GetAnimator();
        stateMachine = new StateMachineBase();

        AllyIdleStateSOBase = Instantiate(allyIdleStateSOBase);
        AllyAttackSOBase = Instantiate(allyAttackSOBase);

        allyIdleState = new AllyIdleState(stateMachine, this);
        allyAttackState = new AllyAttackBase(stateMachine, this);
        RB = GetComponent<Rigidbody2D>();



        AllyIdleStateSOBase.Init(this, transform, gameObject);
        AllyAttackSOBase.Init(this, transform, gameObject);






    }
    void GetAnimator()
    {
        animator = GetComponentInChildren<Animator>();
        if (!animator) GetComponent<Animator>();
    }
    public void Update()
    {
        stateMachine.CurrentState.FrameUpdate();
    }
    public void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicUpdate();
    }
    private void Start()
    {
        stateMachine.Init(allyIdleState);
        speed = 2f;
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public virtual void CheckForFaceDir(Vector2 dir)
    {
        if (IsFacingRight && dir.x < 0f)
        {
            Vector3 rotator = new Vector3(0f, 0f, 0f);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && dir.x > 0f)
        {

            Vector3 rotator = new Vector3(0f, 180f, 0f);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
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
   

    public void Move(Vector2 dir)
    {
        if (dir == Vector2.zero) return;

        Vector2 transVec2 = new Vector2(transform.position.x, transform.position.y);
        RB.MovePosition(transVec2 + dir * (Time.deltaTime * speed));
        CheckForFaceDir(dir);
    }
}
