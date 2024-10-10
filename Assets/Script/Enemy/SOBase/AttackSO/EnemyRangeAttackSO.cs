using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-Shoot", menuName = "Enemy/Attack/Shot")]

public class EnemyRangeAttackSO : EnemyAttackSOBase
{
    private string m_animationName = "Shot";
    public override void DoEnterState()
    {
        base.DoEnterState();
        enemy.animator.Play(m_animationName);
    }
    public override void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        if (enemy.CheckAnimationStateIsPlaying(m_animationName)) return;
        enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);

    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
        enemy.HandleRangeAttackAttack();
    }
}
