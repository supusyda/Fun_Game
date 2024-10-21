using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IMoveAle, ITriggerCheck, IHandleAttack, IInvicible
{
    // Start is called before the first frame update
    [SerializeField] protected Transform SeeTargetIndicator;
    public bool IsFacingRight { get; set; } = false;
    public float speed { get; set; } = 1f;
    public bool isArgo { get; set; }
    public bool isInvicible { get; set; } = false;
    public bool isAttackWithInLongRange { get; set; }
    public bool isAttackWithInRange { get; set; }
    public Rigidbody2D RB { get; set; }
    public DangerZone dangerZone { get; private set; }
    public Collider2D enemyHitBox { get; set; }
    public Animator animator { get; set; }
    public Transform target;
    public StateTxt stateTxt;

    [SerializeField] private int cost;
    public int Cost
    {
        get
        {
            return cost <= 0 ? 1 : cost;
        }
        private set => cost = value;
    }

    public Vector3 moveDir;

    [SerializeField] private EnemyAttackSOBase enemyAttackSOBase;
    [SerializeField] private EnemyChasingSOBase enemyChasingSOBase;
    [SerializeField] private EnemyRoamingSOBase enemyRoamingSOBase;

    public EnemyAttackSOBase EnemyAttackSOBase;
    public EnemyChasingSOBase EnemyChasingSOBase;
    public EnemyRoamingSOBase EnemyRoamingSOBase;


    public EnemyChasingState enemyChasingState;
    public EnemyStateMachine enemyStateMachine;
    public EnemyRoamingState enemyRoamingState;
    public EnemyDamageState enemyDamageState;
    public EnemyAttackState enemyAttackState;


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
        dangerZone = GetComponentInChildren<DangerZone>();
        speed = 1f;
        enemyStateMachine.Init(enemyRoamingState);
        SeeTargetIndicator.gameObject.SetActive(false);

    }
    public void OnDie()
    {
        setIsArgo(false);
        setAttackWithInLongRange(false);
        setAttackWithInRange(false);
        Move(Vector2.zero);
        enemyStateMachine.ChangeState(enemyDamageState);
    }
    protected void ShowSeeTargetIndicatorUI()
    {
        SeeTargetIndicator.gameObject.SetActive(true);

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
        // Debug.Log(isArgo);
    }
    private void FixedUpdate()
    {
        enemyStateMachine.CurrentEnemyState.PhysicUpdate();
    }
    public void Move(Vector2 dir)
    {
        moveDir = dir;
        // Debug.Log("" + moveDir);
        Vector2 transformVec2 = new Vector2(transform.position.x, transform.position.y);
        RB.MovePosition(transformVec2 + dir * (Time.deltaTime * speed));
        if (dir == Vector2.zero) return;

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
    public bool HaveTarget()
    {
        return target != null;
    }
    #region AnimationTriggerEvent
    public void AnimationTrigger(AnimationTriggerEvent triggerEvent)
    {
        enemyStateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerEvent);
    }


    public enum AnimationTriggerEvent
    {
        EnemyDamage,
        PlayFootStep,
        EnableAttackCollider,
        DisableAttackCollider,
        BeginExplosive,
        Shot
    }
    #endregion
    #region Trigger

    public void setIsArgo(bool isArgo)
    {
        this.isArgo = isArgo;
        if (isArgo == true) ShowSeeTargetIndicatorUI();

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
    public virtual void HandleRangeAttackAttack()
    {


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
        // if (this.isInvicible) return;
        // StartCoroutine(invincibleIntime(time));
    }

    public void setAttackWithInLongRange(bool isAttackWithInLongRange)
    {
        isAttackWithInRange = isAttackWithInLongRange;
    }

    #endregion
    public bool CheckAnimationStateIsPlaying(string currentAnimationPlay)
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(currentAnimationPlay) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            return true;
        return false;
    }

}
