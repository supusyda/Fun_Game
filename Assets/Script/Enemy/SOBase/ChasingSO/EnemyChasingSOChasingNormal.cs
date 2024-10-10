using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Chasing-Normal", menuName = "Enemy/Chasing/Normal")]
public class EnemyChasingSOChasingNormal : EnemyChasingSOBase
{
    Avoid avoid;
    public float chasingSpeed;
    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);

    }
    public override void DoEnterState()
    {

        base.DoEnterState();
        enemy.animator.CrossFade("Run", 0);
        avoid = transform.GetComponentInChildren<Avoid>();
        enemy.SetSpeed(chasingSpeed);

    }
    public override void DoExitState()
    {
        base.DoExitState();
    }
    public override void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        if (!enemy.isArgo) { enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState); return; }
        if (enemy.isAttackWithInRange)
        {
            enemy.enemyStateMachine.ChangeState(enemy.enemyAttackState);
            return;
        }

        Vector2 dir = (enemy.target.position - enemy.transform.position).normalized;
        if (avoid)
        {

            dir = dir + (Vector2)avoid.GetAvoidDir();
            // Debug.Log("(Vector2)avoid.GetAvoidDir()" + (Vector2)avoid.GetAvoidDir());

        }


        enemy.Move(dir.normalized);

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
    public override void OnDrawGrizmos()
    {
        base.OnDrawGrizmos();
    }

}
