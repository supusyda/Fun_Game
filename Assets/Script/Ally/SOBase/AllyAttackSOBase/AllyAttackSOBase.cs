using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ally-Attack", menuName = "Ally/Attack/Normal")]
public class AllyAttackSOBase : StateSOBase
{
    // Start is called before the first frame update
    AllyBase ally;

    public float attackCooldown = 1f;
    public float attackCooldownTimer = 0f;
    public virtual void Init(AllyBase ally, Transform transform, GameObject gameObject)
    {
        this.ally = ally;
        this.transform = transform;
        this.gameObject = gameObject;

    }
    override public void DoEnterState()
    {
        base.DoEnterState();
        ally.animator.Play("Attack");
        // this.attackCooldownTimer = 0f;

    }
    override public void DoExitState()
    {
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        if (ally.isAttackWithInLongRange != true && !CheckAnimationStateIsPlaying("Attack")) { ally.stateMachine.ChangeState(ally.allyIdleState); return; };

        this.attackCooldownTimer += Time.deltaTime;
        if (!CheckAnimationStateIsPlaying("Attack"))
        {
            ally.animator.Play("Idle");
            
        }
        if (this.attackCooldownTimer < this.attackCooldown) return;


        ally.animator.Play("Attack");
        this.attackCooldownTimer = 0f;

    }
    override public void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();

    }
    override public void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void ResetValue()
    {
        base.ResetValue();
    }
    public bool CheckAnimationStateIsPlaying(string State)
    {

        if (ally.animator.GetCurrentAnimatorStateInfo(0).IsName(State) && ally.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            return true;
        return false;
    }
}
