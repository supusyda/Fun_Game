using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Roaming-random", menuName = "Enemy/Roaming/Random")]
public class EnemyRandomRoamingSO : EnemyRoamingSOBase
{
    // Start is called before the first frame update
    [SerializeField] public float maxRoamingRange = 5f;
    [SerializeField] public Vector3 startedPos;
    private Vector3 targetPosition;
    private Vector3 randDir;
    private float speed = 1f;

    override public void Init(EnemyBase enemy, Transform transform, GameObject gameObject)
    {
        base.Init(enemy, transform, gameObject);
    }
    override public void DoEnterState()
    {
        // Debug.Log("ENEMY ENTER ROAM");

        base.DoEnterState();
        enemy.animator.Play("Run");
        InitRandRoaming();
        enemy.SetSpeed(speed);

    }
    override public void DoExitState()
    {
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        Roaming();
        if (enemy.isArgo == true) enemy.enemyStateMachine.ChangeState(enemy.enemyChasingState);
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
    private void Roaming()
    {
        enemy.Move(randDir);
        if (Vector3.Distance(enemy.transform.position, targetPosition) <= 1f)
        {
            // reach rand roaming pos 
            //if this object reach the randPos or move pass the maxRoamingRange then
            //cal rand roaming pos again
            InitRandRoaming();
        }
        // else if(Vector3.Distance(enemy.transform.position, startedPos) >= maxRoamingRange)
        // {

        // }
    }
    Vector3 GetRoamingPosition()
    {
        // get rand roaming pos reletive to the started pos of the oject
        float rand = UnityEngine.Random.Range(1f, maxRoamingRange);
        Vector3 vector3 = startedPos + GetRandomDirection() * rand;
        return vector3;
    }
    Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized;
    }
    void InitRandRoaming()
    {
        targetPosition = GetRoamingPosition();
        // Debug.Log("targetPosition" + targetPosition);
        if (targetPosition == null) return;
        randDir = (targetPosition - enemy.transform.position).normalized;

    }
    public override void OnDrawGrizmos()
    {
        base.OnDrawGrizmos();
    }
}
