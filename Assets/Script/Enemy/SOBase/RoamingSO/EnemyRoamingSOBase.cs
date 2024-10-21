using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingSOBase : ScriptableObject
{
    protected EnemyBase enemy;
    protected Transform _transform;
    GameObject gameObject;

    public virtual void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        this.enemy = enemy;
        _transform = transform;
        this.gameObject = gameObject;

    }
    public virtual void DoEnterState()
    {

    }
    public virtual void DoExitState()
    {

    }
    public virtual void DoFrameUpdate()
    {
        // if (enemy.isArgo == true) { enemy.enemyStateMachine.ChangeState(enemy.enemyChasingState); return; };
    }
    public virtual void DoPhysicUpdate()
    {

    }
    public virtual void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {

    }
    public virtual void ResetValue()
    {

    }
    public virtual void OnDrawGrizmos()
    {
        // base.OnDrawGrizmos();
    }

}
