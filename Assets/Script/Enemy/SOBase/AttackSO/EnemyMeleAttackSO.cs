using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-Melee", menuName = "Enemy/Attack/Melee")]
public class EnemyMeleAttackSO : EnemyAttackSOBase
{
    // Start is called before the first frame update
    [SerializeField] private float m_cooldownTime;
    private float m_cooldownTimerTickDown;

    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);
    }
    override public void DoEnterState()
    {
        base.DoEnterState();
        
        enemy.animator.Play("Attack", 0);
        m_cooldownTimerTickDown = m_cooldownTime;
        

    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void DoExitState()
    {
        base.DoExitState();
    }
    override async public void DoFrameUpdate()
    {
        // base.DoFrameUpdate();
        // enemy.Move(Vector2.zero);
        if (enemy.CheckAnimationStateIsPlaying("Attack")) return;
        if (m_cooldownTimerTickDown > 0)
        {
            enemy.animator.Play("Idle", 0);
            m_cooldownTimerTickDown -= Time.deltaTime;
            return;
        }



        if (!enemy.isAttackWithInRange && !enemy.isArgo)
        {
            enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);
            return;
        }
        if (!enemy.isAttackWithInRange)
        {
            enemy.enemyStateMachine.ChangeState(enemy.enemyChasingState);
            return;
        }
       
        enemy.enemyStateMachine.ChangeState(enemy.enemyAttackState);

    }


    override public void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();
    }
    public override void OnDrawGrizmos()
    {
        base.OnDrawGrizmos();
    }
}
