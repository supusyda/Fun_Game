using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-ChargeAtPlayer", menuName = "Enemy/Attack/Charge")]

public class EnemyAttackChrageSoBase : EnemyAttackSOBase

{
    // Start is called before the first frame update
    public int chargeTime = 1;
    float chargeTimeCount = 0;
    float cooldownTime = 2;
    float cooldownTimer = 0;
    Vector3 playerPos;

    public float force = 2;
    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);
    }
    override public async void DoEnterState()
    {
        base.DoEnterState();
        enemy.animator.Play("Idle");

        enemy.Move(Vector2.zero);
        playerPos = new Vector3(player.position.x, player.position.y, 0);
        Vector2 chargeDir = (playerPos - transform.position).normalized;//get dir form enemy to player then normalize
        Vector3 forceVec = chargeDir * force;
        enemy.dangerZone.SetPos(transform.position + forceVec / 2);
        await Task.Delay(chargeTime * 1000);
        if (enemy.enemyStateMachine.CurrentEnemyState != enemy.enemyAttackState) return;

        ChargeAtTarget(forceVec);
    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void DoExitState()
    {
        base.DoExitState();
        enemy.dangerZone.ClearPos();

    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
    }
    async void ChargeAtTarget(Vector3 chargeDir)
    {

        enemy.RB.AddForce(chargeDir, ForceMode2D.Impulse);
        enemy.dangerZone.ClearPos();

        await Task.Delay((int)cooldownTime * 1000);
        if (enemy.enemyStateMachine.CurrentEnemyState != enemy.enemyAttackState) return;

        enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);
    }

    override public void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();
    }
}
