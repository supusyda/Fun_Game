using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyOnComandMoveState : AllyStateBase
{
    // Start is called before the first frame update

    Crew crew;
    public AllyOnComandMoveState(StateMachineBase stateMachine, AllyBase allyBase) : base(stateMachine, allyBase)
    {
        crew = (Crew)allyBase;
    }
    public override void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
    }
    override public void EnterState()
    {
       
        base.EnterState();

        crew.AllyOnComandSOBase.DoEnterState();
    }
    override public void FrameUpdate()
    {
        base.FrameUpdate();

        crew.AllyOnComandSOBase.DoFrameUpdate();
    }
    override public void PhysicUpdate()
    {
        base.PhysicUpdate();
        crew.AllyOnComandSOBase.DoPhysicUpdate();
    }
    override public void ExitState()
    {
        base.ExitState();
        crew.AllyOnComandSOBase.DoExitState();
    }
}
