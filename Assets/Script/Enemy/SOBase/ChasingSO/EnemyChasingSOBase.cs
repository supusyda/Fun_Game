using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyChasingSOBase : ScriptableObject
{
  protected EnemyBase enemy;
  protected Transform transform;
  protected GameObject gameObject;
  protected Transform player;
  public virtual void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
  {
    this.enemy = enemy;
    this.transform = transform;
    this.gameObject = gameObject;
    this.player = GameObject.FindGameObjectWithTag("Player").transform;
  }
  public virtual void DoEnterState()
  {

  }
  public virtual void DoExitState()
  {

  }
  public virtual void DoFrameUpdate()
  {
    if (!enemy.isArgo) { enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState); return; }
    if (enemy.isAttackWithInRange)
    {
      enemy.enemyStateMachine.ChangeState(enemy.enemyAttackState);
      return;
    }
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


}
