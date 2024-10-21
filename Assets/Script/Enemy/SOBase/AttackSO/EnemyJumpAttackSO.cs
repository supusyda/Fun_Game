using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-jump", menuName = "Enemy/Attack/Jump")]

public class EnemyJumpAttackSO : EnemyAttackSOBase
{
    private string m_animationName = "Jump";
    private bool doneJump = false;

    public float attackCooldown = 1f;
    private float _attackCooldownTimer = 0f;
    public override void DoEnterState()
    {
        base.DoEnterState();
        enemy.animator.Play(m_animationName);
        doneJump = false;

        JumpUp();

    }
    void JumpUp()
    {

        transform.DOJump(enemy.target.position, 1, 1, 2).OnComplete(() =>
          {

              doneJump = true;
          });
    }

    public override void DoFrameUpdate()
    {
        if (doneJump == false) return;
        base.DoFrameUpdate();
        _attackCooldownTimer += Time.deltaTime;
        if (_attackCooldownTimer < this.attackCooldown) return;


        // if (enemy.CheckAnimationStateIsPlaying(m_animationName)) return;
        enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);

    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);

    }
    public override void DoExitState()
    {
        base.DoExitState();
        doneJump = false;
        _attackCooldownTimer = 0f;
        DOTween.Kill(transform);

    }
}
