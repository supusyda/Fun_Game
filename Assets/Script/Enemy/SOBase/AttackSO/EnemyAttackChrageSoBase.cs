using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-ChargeAtPlayer", menuName = "Enemy/Attack/Charge")]

public class EnemyAttackChrageSoBase : EnemyAttackSOBase

{
    // Start is called before the first frame update
    public float chargeTime = 1;
    private float chargeTimeCounter = 0;


    public float cooldownTime = 2;
    private float cooldownTimeCounter = 0;
    bool _doneCharge = false;



    Vector3 targetPos;
    Rigidbody2D rigidbody2D;

    public float force = 2;
    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }
    override public void DoEnterState()
    {
        rigidbody2D.velocity = Vector3.zero;
        targetPos = enemy.target.position;

    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
    }
    override public void DoExitState()
    {
        base.DoExitState();
        chargeTimeCounter = 0;// reset counter
        cooldownTimeCounter = 0;// reset counter
        _doneCharge = false;// reset flag
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.angularVelocity = 0;//stop move by physic   
    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        if (_doneCharge == true) // if done charge at player than begin cooldown
        {
            chargeTimeCounter = 0;
            if (cooldownTimeCounter < cooldownTime)
            {
                cooldownTimeCounter += Time.deltaTime;
                return;
            };
            rigidbody2D.velocity = Vector3.zero;
            enemy.enemyStateMachine.ChangeState(enemy.enemyChasingState);
        }
        else
        {
            if (chargeTimeCounter < chargeTime)
            {
                chargeTimeCounter += Time.deltaTime;
                return;
            }
            ChargeAtTarget();
        }


    }
    void ChargeAtTarget()
    {
        Vector3 newTargetDir = (targetPos - transform.position);
        newTargetDir.z = 0;
        newTargetDir.Normalize();
        enemy.Move(newTargetDir);// rotate to dir
        rigidbody2D.AddForce(newTargetDir * force, ForceMode2D.Impulse);
        _doneCharge = true;
    }

    override public void DoPhysicUpdate()
    {
        base.DoPhysicUpdate();
    }
}
