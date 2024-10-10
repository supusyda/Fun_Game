using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSOBase : ScriptableObject
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
        // this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.player = GameObject.FindGameObjectWithTag("Player") ? GameObject.FindGameObjectWithTag("Player").transform : null;

    }
    public virtual void DoEnterState()
    {

    }
    public virtual void DoExitState()
    {

    }
    public virtual void DoFrameUpdate()
    {

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
        
    }
}
