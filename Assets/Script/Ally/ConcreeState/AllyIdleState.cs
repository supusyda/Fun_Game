using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyIdleState : AllyStateBase
{
    // Start is called before the first frame update
    public AllyIdleState(StateMachineBase stateMachine, AllyBase allyBase) : base(stateMachine, allyBase)
    {

    }
    public override void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
    }
    override public void EnterState()
    {
        base.EnterState();
        Debug.Log("ENTER STATE IDLE");
        allyBase.AllyIdleStateSOBase.DoEnterState();
    }
    override public void FrameUpdate()
    {
        base.FrameUpdate();
        allyBase.AllyIdleStateSOBase.DoFrameUpdate();
    }
    override public void PhysicUpdate()
    {
        base.PhysicUpdate();
        allyBase.AllyIdleStateSOBase.DoPhysicUpdate();
    }
    override public void ExitState()
    {
        base.ExitState();
        allyBase.AllyIdleStateSOBase.DoExitState();
    }
}
