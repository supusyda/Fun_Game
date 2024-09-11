using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyChasingState : AllyStateBase
{
    // Start is called before the first frame update

    Crew crew;
    public AllyChasingState(StateMachineBase stateMachine, AllyBase allyBase) : base(stateMachine, allyBase)
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

        crew.AllyChasingSOBase.DoEnterState();
    }
    override public void FrameUpdate()
    {
        base.FrameUpdate();

        crew.AllyChasingSOBase.DoFrameUpdate();
    }
    override public void PhysicUpdate()
    {
        base.PhysicUpdate();
        crew.AllyChasingSOBase.DoPhysicUpdate();
    }
    override public void ExitState()
    {
        base.ExitState();
        crew.AllyChasingSOBase.DoExitState();
    }
}
