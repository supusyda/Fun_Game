using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyStateBase
{
    // Start is called before the first frame update
    public EnemyChasingState(EnemyBase enemyBase, EnemyStateMachine enemyStateMachine) : base(enemyBase, enemyStateMachine)
    {


    }
    public override void EnterState()
    {
        base.EnterState();
        // enemyBase.animator.Play("Run");
        
        enemyBase.EnemyChasingSOBase.DoEnterState();

    }
    override public void FrameUpdate()
    {
        base.FrameUpdate();
        // not argo change to roaming state
      enemyBase.EnemyChasingSOBase.DoFrameUpdate();


    }
    override public void PhysicUpdate()
    {
        base.PhysicUpdate();
        enemyBase.EnemyChasingSOBase.DoPhysicUpdate();
    }
    override public void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
        enemyBase.EnemyChasingSOBase.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void ExitState()
    {
        base.ExitState();
        enemyBase.EnemyChasingSOBase.DoExitState();
    }
}
