using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Chasing-Normal", menuName = "Enemy/Chasing/Normal")]
public class EnemyChasingSOChasingNormal : EnemyChasingSOBase
{
    public float chasingSpeed;
    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);
    }
    public override void DoEnterState()
    {
        base.DoEnterState();
        enemy.animator.Play("Run");

        enemy.SetSpeed(chasingSpeed);

    }
    public override void DoExitState()
    {
        base.DoExitState();
    }
    public override void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        if (enemy.target == null)
        {
            enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);
            return;
        }
        Vector2 dir = (enemy.target.position - enemy.transform.position).normalized;
        enemy.MoveEnemy(dir);
    }
    public override void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();
    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);

    }
    public override void ResetValue()
    {
        base.ResetValue();
    }


}
