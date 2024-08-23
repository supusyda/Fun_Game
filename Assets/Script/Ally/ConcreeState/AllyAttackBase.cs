using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttackBase : AllyStateBase
{
    // Start is called before the first frame update


    public AllyAttackBase(StateMachineBase stateMachine, AllyBase allyBase) : base(stateMachine, allyBase)
    {

    }
    public override void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
    }
    override public void EnterState()
    {
        base.EnterState();
        // Debug.Log("ENTER STATE Attack");
        allyBase.AllyAttackSOBase.DoEnterState();
    }
    override public void FrameUpdate()
    {
        base.FrameUpdate();
       
        allyBase.AllyAttackSOBase.DoFrameUpdate();
    }
    override public void PhysicUpdate()
    {
        base.PhysicUpdate();
        allyBase.AllyAttackSOBase.DoPhysicUpdate();
    }
    override public void ExitState()
    {
        base.ExitState();
        allyBase.AllyAttackSOBase.DoExitState();
    }
}
