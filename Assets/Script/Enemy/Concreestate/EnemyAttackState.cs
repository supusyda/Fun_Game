using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    // Start is called before the first frame update

    private Transform _player;
    private float _attackDelayTime = 1f;

    private float _attackDelayTimerCount;
    private float _exitTimer;
    private float _timeTillExit = 3f;
    private float _distantToCountExit = 3f;

    public EnemyAttackState(EnemyBase enemyBase, EnemyStateMachine enemyStateMachine) : base(enemyBase, enemyStateMachine)
    {


    }
    public override void EnterState()
    {
     
        base.EnterState();
        enemyBase.EnemyAttackSOBase.DoEnterState();
        Debug.Log("ENTER STATE ATTACK");

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
      enemyBase.EnemyAttackSOBase.DoFrameUpdate();

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        enemyBase.EnemyAttackSOBase.DoPhysicUpdate();
    }
    public override void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
        enemyBase.EnemyAttackSOBase.DoAnimationTriggerEvent(triggerEvent);
    }
    public override void ExitState()
    {
        base.ExitState();
        enemyBase.EnemyAttackSOBase.DoExitState();
    }



}
