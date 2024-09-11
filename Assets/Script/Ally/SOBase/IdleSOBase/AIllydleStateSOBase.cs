using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ally-Idle", menuName = "Ally/Idle/Normal")]
public class AllyIdleStateSOBase : StateSOBase
{
    protected AllyBase ally;

    public virtual void Init(AllyBase ally, Transform transform, GameObject gameObject)
    {
        this.ally = ally;
        this.transform = transform;
        this.gameObject = gameObject;

    }
    override public void DoEnterState()
    {
        base.DoEnterState();
        ally.animator.Play("Idle");

    }
    override public void DoExitState()
    {
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        // if(ally.isArgo==true)ally.stateMachine.ChangeState(ally.chasin)
        if (ally.isAttackWithInLongRange == true || ally.isAttackWithInRange==true) ally.stateMachine.ChangeState(ally.allyAttackState);
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

}
