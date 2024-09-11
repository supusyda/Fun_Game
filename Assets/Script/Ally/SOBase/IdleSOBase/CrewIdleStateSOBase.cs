using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Crew-Idle", menuName = "Crew/Idle/Normal")]
public class CrewIdleStateSOBase : AllyIdleStateSOBase
{
    Crew crew;

    public override void Init(AllyBase ally, Transform transform, GameObject gameObject)
    {
        base.Init(ally, transform, gameObject);
        crew = transform.GetComponent<Crew>();

    }
    override public void DoEnterState()
    {
        base.DoEnterState();
        ally.animator.Play("Idle");

    }
    override public void DoExitState()
    {
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        if (crew.isArgo == true) { crew.stateMachine.ChangeState(crew.AllyChasing); return; }
        if (crew.isAttackWithInLongRange == true || crew.isAttackWithInRange == true) crew.stateMachine.ChangeState(crew.allyAttackState);
    }
    override public void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();
    }
    override public void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void ResetValue()
    {
        base.ResetValue();
    }

}
