using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IMoveAle, ITriggerCheck, IHandleAttack, IInvicible
{
    // Start is called before the first frame update
    public Rigidbody2D RB { get; set; }
    public Collider2D enemyHitBox { get; set; }
    public Animator animator { get; set; }
    public bool IsFacingRight { get; set; } = false;
    public float speed { get; set; } = 1f;
    public bool isArgo { get; set; }
    public bool isAttackWithInRange { get; set; }
    public Transform target;

    public EnemyChasingState enemyChasingState { get; set; }
    public bool isInvicible { get; set; } = false;
    public bool isAttackWithInLongRange { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    [SerializeField] private EnemyAttackSOBase enemyAttackSOBase;
    [SerializeField] private EnemyChasingSOBase enemyChasingSOBase;
    [SerializeField] private EnemyRoamingSOBase enemyRoamingSOBase;

    public EnemyAttackSOBase EnemyAttackSOBase;
    public EnemyChasingSOBase EnemyChasingSOBase;
    public EnemyRoamingSOBase EnemyRoamingSOBase;


    public EnemyStateMachine enemyStateMachine;
    public EnemyRoamingState enemyRoamingState;
    public EnemyDamageState enemyDamageState;
    public EnemyStateBase enemyAttackState;


    private void Awake()
    {
        // EnemyAttackSOBase = Instantiate(enemyAttackSOBase);
        EnemyChasingSOBase = Instantiate(enemyChasingSOBase);
        EnemyRoamingSOBase = Instantiate(enemyRoamingSOBase);
        EnemyAttackSOBase = Instantiate(enemyAttackSOBase);


        enemyStateMachine = new EnemyStateMachine();
        enemyChasingState = new EnemyChasingState(this, enemyStateMachine);
        enemyRoamingState = new EnemyRoamingState(this, enemyStateMachine);
        enemyAttackState = new EnemyAttackState(this, enemyStateMachine);
        enemyDamageState = new EnemyDamageState(this, enemyStateMachine);


        enemyHitBox = transform.GetComponent<Collider2D>();


        EnemyRoamingSOBase.Init(this, transform, gameObject);
        EnemyChasingSOBase.Init(this, transform, gameObject);
        EnemyAttackSOBase.Init(this, transform, gameObject);


  

    }
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        speed = 1f;
        enemyStateMachine.Init(enemyRoamingState);

    }
 public void  OnDie()
    {

    }
    public void CheckForFaceDir(Vector2 dir)
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
    private void Update()
    {
        enemyStateMachine.CurrentEnemyState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        enemyStateMachine.CurrentEnemyState.PhysicUpdate();
    }
    public void MoveEnemy(Vector2 dir)
    {
        if (dir == Vector2.zero) return;
        Vector2 transVec2 = new Vector2(transform.position.x, transform.position.y);
        RB.MovePosition(transVec2 + dir * (Time.deltaTime * speed));
        CheckForFaceDir(dir);
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    #region AnimationTriggerEvent
    void AnimationTrigger(AnimationTriggerEvent triggerEvent)
    {
        enemyStateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerEvent);
    }


    public enum AnimationTriggerEvent
    {
        EnemyDamage,
        PlayFootStep
    }
    #endregion
    #region Trigger

    public void setIsArgo(bool isArgo)
    {
        this.isArgo = isArgo;
    }

    public void setAttackWithInRange(bool isAttackWithInRange)
    {
        this.isAttackWithInRange = isAttackWithInRange;
    }




    #endregion
    #region HandleAttack
    public void HandleAttack()
    {
        if (!this.isAttackWithInRange)
        {

        }

    }

    public IEnumerator invincibleIntime(float time)
    {
        this.isInvicible = true;
        enemyHitBox.enabled = false;
        yield return new WaitForSeconds(time);
        enemyHitBox.enabled = true;
        this.isInvicible = false;
    }

    public void StartCoroutineInvincibleIntime(float time)
    {
        if (this.isInvicible) return;
        StartCoroutine(invincibleIntime(time));
    }

    public void setAttackWithInLongRange(bool isAttackWithInLongRange)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
