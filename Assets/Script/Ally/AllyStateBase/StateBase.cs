using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    // Start is called before the first frame update\
    protected StateMachineBase stateMachine;
   public StateBase(StateMachineBase stateMachine) 
   {
    this.stateMachine = stateMachine;
   }
    public virtual void EnterState()
    {

    }
    public virtual void FrameUpdate()
    {

    }
    public virtual void ExitState()
    {

    }
    public virtual void PhysicUpdate()
    {

    }
    public virtual void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {

    }
}
