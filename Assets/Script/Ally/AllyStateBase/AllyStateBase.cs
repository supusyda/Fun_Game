using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyStateBase : StateBase
{
    // Start is called before the first frame update
    protected AllyBase allyBase;



    public AllyStateBase(StateMachineBase stateMachine, AllyBase allyBase) : base(stateMachine)
    {
        this.allyBase = allyBase;
        this.stateMachine = stateMachine;
    }
    public override void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
    }
    public override void EnterState()
    {
        base.EnterState();
        allyBase.stateTxt?.SetText(this.GetType().Name);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }
    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
