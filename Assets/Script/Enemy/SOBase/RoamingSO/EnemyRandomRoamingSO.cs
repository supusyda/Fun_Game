using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Roaming-random", menuName = "Enemy/Roaming/Random")]
public class EnemyRandomRoamingSO : EnemyRoamingSOBase
{
    // Start is called before the first frame update
    [SerializeField] public float maxRoamingRange = 5f;
    [SerializeField] public Vector3 startedPos;
    [SerializeField] private float timeChangeRoamingPos = 4f;
    [SerializeField] private float changeRoamingPosTimer;
    private Vector2 targetPosition;
    private Vector2 randDir;
    private float speed = 1f;
    Avoid avoid;
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
        avoid = _transform.GetComponentInChildren<Avoid>();
        changeRoamingPosTimer = 0;

    }
    override public void DoExitState()
    {
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {
        if (enemy.isArgo == true) enemy.enemyStateMachine.ChangeState(enemy.enemyChasingState);
        base.DoFrameUpdate();
        UpdateRoaming();
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
    private void UpdateRoaming()
    {
        Vector2 dir = randDir;
        if (avoid) dir = dir + (Vector2)avoid.GetAvoidDir();

        enemy.Move(randDir);

        if (canChangeRoamingPos())
        {
            // reach rand roaming pos 
            //if this object reach the randPos or move pass the maxRoamingRange then
            //cal rand roaming pos again
            InitRandRoaming();
            changeRoamingPosTimer = 0;
        }
        else
        {
            changeRoamingPosTimer += Time.deltaTime;
        }

    }
    Vector3 GetRoamingPositionNearStartPos()
    {
        // get rand roaming pos reletive to the started pos of the oject
        float rand = UnityEngine.Random.Range(1f, maxRoamingRange);
        // Vector3 vector3 = startedPos + GetRandomDirection() * rand;
        Vector3 point = (Random.insideUnitSphere * maxRoamingRange) + startedPos;
        return point;
    }
    void InitRandRoaming()
    {
        targetPosition = RandomPositionGen.GenRandPosWithInSphere(maxRoamingRange, startedPos);
        randDir = (targetPosition - (Vector2)enemy.transform.position);
        randDir.Normalize();

    }
    private bool canChangeRoamingPos()
    {
        return Vector3.Distance(enemy.transform.position, targetPosition) <= .1f || changeRoamingPosTimer >= timeChangeRoamingPos;
    }
    public override void OnDrawGrizmos()
    {
        base.OnDrawGrizmos();
    }
}
public class RandomPositionGen
{
    public static Vector3 GenRandPosWithInSphere(float maxRoamingRange, Vector3 startedPos)
    {
        float rand = UnityEngine.Random.Range(1f, maxRoamingRange);
        // Vector3 vector3 = startedPos + GetRandomDirection() * rand;
        Vector3 point = (Random.insideUnitSphere * maxRoamingRange) + startedPos;
        return point;
    }
}