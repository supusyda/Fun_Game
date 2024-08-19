using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateSOBase : ScriptableObject
{
    // Start is called before the first frame update
    protected Transform transform;
    protected GameObject gameObject;

   
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

}
