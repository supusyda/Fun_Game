using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageState : EnemyStateBase
{
    float timeInvincible = .4f;
    float timer = 0;
    public EnemyDamageState(EnemyBase enemyBase, EnemyStateMachine enemyStateMachine) : base(enemyBase, enemyStateMachine)
    {
    }
    override public void EnterState()
    {
        base.EnterState();
        enemyBase.animator.Play("GetHit");
        enemyBase.StartCoroutineInvincibleIntime(timeInvincible);
        // Debug.Log("ENTER STATE DAMAGE");
        timer = 0;

    }
    override public void FrameUpdate()
    {
        base.FrameUpdate();
        if (timer >= timeInvincible) { enemyStateMachine.ChangeState(enemyBase.enemyRoamingState); return; }
        timer += Time.deltaTime;



    }
    override public void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    override public void AnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.AnimationTriggerEvent(triggerEvent);
    }
    override public void ExitState()
    {
        base.ExitState();
        timer = 0;
    }
    // Start is called before the first frame update

}
