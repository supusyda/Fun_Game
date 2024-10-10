using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-ChargeAtPlayer", menuName = "Enemy/Attack/Charge")]

public class EnemyAttackChrageSoBase : EnemyAttackSOBase

{
    // Start is called before the first frame update
    public int chargeTime = 1;

    float cooldownTime = 2;

    Vector3 targetPos;
    Vector3 forceVec;

    public float force = 2;
    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);
    }
    override public async void DoEnterState()
    {
        // base.DoEnterState();
        // enemy.animator.CrossFade("Attack", 0f);
        // // enemy.animator.GetCurrentAnimatorStateInfo(0).;
        Debug.Log("START CHARGE");
        // enemy.Move(Vector2.zero);
        // targetPos = new Vector3(enemy.target.position.x, enemy.target.position.y, 0);
        // Vector2 chargeDir = (targetPos - transform.position).normalized;//get dir form enemy to player then normalize
        // forceVec = chargeDir * force;
        // enemy.dangerZone.SetPos(transform.position + forceVec / 10);
        // enemy.force = forceVec;
        // await Task.Delay(chargeTime * 1000);
        // if (enemy.enemyStateMachine.CurrentEnemyState != enemy.enemyAttackState) return;


        ChargeAtTarget(forceVec);

    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void DoExitState()
    {
        base.DoExitState();
        // enemy.dangerZone.ClearPos();

    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
    }
    async void ChargeAtTarget(Vector3 chargeDir)
    {
        //clear the danger zone
        // enemy.dangerZone.ClearPos();

        // //push the oject
        // enemy.RB.AddForce(chargeDir, ForceMode2D.Impulse);
        // // awit task will alway do enevnt when change to other state
        // Debug.Log("CHARGE");
        await Task.Delay((int)cooldownTime * 1000);
        // Debug.Log("End CHARGE");

        // enemy.Move(Vector2.zero);

        if (enemy.enemyStateMachine.CurrentEnemyState != enemy.enemyAttackState) return;
        enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);
    }

    override public void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();
    }
}
