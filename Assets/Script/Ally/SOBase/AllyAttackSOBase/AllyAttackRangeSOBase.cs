using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ally-Attack", menuName = "Ally/Attack/Normal/Range")]
public class AllyAttackRangeSOBase : AllyAttackSOBase
{
    // Start is called before the first frame update

    float attackCooldownTimer = 0f;

    override public void DoEnterState()
    {
        ally.animator.Play("Attack");
        this.attackCooldownTimer = 0f;
        base.DoEnterState();


    }
    override public void DoExitState()
    {
        base.DoExitState();

    }
    override public void DoFrameUpdate()
    {
        // base.DoFrameUpdate();
        if (ally.isAttackWithInLongRange != true && !CheckAnimationStateIsPlaying("Attack"))
        {
            ally.stateMachine.ChangeState(ally.allyIdleState); return;
        };

        // if (!ally.isAttackWithInRange && !CheckAnimationStateIsPlaying("Attack"))
        // {
        //     ally.stateMachine.ChangeState(ally.allyIdleState);

        //     return;
        // }
        this.attackCooldownTimer += Time.deltaTime;
        if (this.attackCooldownTimer >= this.attackCooldown)
        {
            Debug.Log("Attack");
            ally.animator.Play("Attack", -1, 0);
            this.attackCooldownTimer = 0f;
        }

    }



}
