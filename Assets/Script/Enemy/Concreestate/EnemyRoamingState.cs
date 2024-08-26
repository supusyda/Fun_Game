using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingState : EnemyStateBase
{
    // Start is called before the first frame update
    public EnemyRoamingState(EnemyBase enemyBase, EnemyStateMachine enemyStateMachine) : base(enemyBase, enemyStateMachine)
    {


    }
    public override void EnterState()
    {
        base.EnterState();
       
        enemyBase.EnemyRoamingSOBase.DoEnterState();

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate(); enemyBase.EnemyRoamingSOBase.DoFrameUpdate();


    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    public override void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
    }
    public override void ExitState()
    {
        base.ExitState();
    }

}
