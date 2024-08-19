using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-Melee", menuName = "Enemy/Attack/Melee")]
public class EnemyMeleAttackSO : EnemyAttackSOBase
{
    // Start is called before the first frame update
    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);
    }
    override public void DoEnterState()
    {
        base.DoEnterState();
        enemy.animator.Play("Attack");

    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void DoExitState()
    {
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        enemy.MoveEnemy(Vector2.zero);
        if(!enemy.isAttackWithInRange && !enemy.isArgo) 
        {
             enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);
            return;
        }
        if (!enemy.isAttackWithInRange)
        {
            enemy.enemyStateMachine.ChangeState(enemy.enemyChasingState);
            return;
        }
    }


    override public void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();
    }
}
