using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase
{
    // Start is called before the first frame update
    protected EnemyBase enemyBase;
    protected EnemyStateMachine enemyStateMachine;
    public EnemyStateBase(EnemyBase enemyBase, EnemyStateMachine enemyStateMachine)
    {
        this.enemyBase = enemyBase;
        this.enemyStateMachine = enemyStateMachine;

    }
    public virtual void EnterState()
    {
        enemyBase.stateTxt.SetText(this.GetType().Name);
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
    public virtual void OnDrawGrizmos()
    {
        
    }
    //OnTriger and exit
}
