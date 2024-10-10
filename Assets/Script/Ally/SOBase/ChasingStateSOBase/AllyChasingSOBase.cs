using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
[CreateAssetMenu(fileName = "Ally-Chasing", menuName = "Ally/Chasing/Normal")]
public class AllyChasingSOBase : StateSOBase
{
    // Start is called before the first frame update
    public float speed;
    protected Crew ally;
    Seeker seeker;
    Path path;
    int currentNode = 0;
    bool endOfPath = false;
    float nextWayponitDistant = .1f;

    public virtual void Init(AllyBase ally, Transform transform, GameObject gameObject)
    {
        this.ally = (Crew)ally;
        this.transform = transform;
        this.gameObject = gameObject;
        seeker = this.ally.seeker;

    }
    override public void DoEnterState()
    {

        base.DoEnterState();
        ally.speed = speed;
        ally.animator.Play("Walk");
        endOfPath = false;

        // randTargetPos = RTSControl.Instance.targetPos + (Vector3)Random.insideUnitCircle.normalized;
        Vector3 newTargetoffset = new Vector3(ally.target.position.x + 0, ally.target.position.y, 0);
        seeker.StartPath(ally.RB.position, newTargetoffset, onCompleCreatePath);
        // this.attackCooldownTimer = 0f;

    }


    private void onCompleCreatePath(Path p)
    {
        if (p.error) return;
        path = p;
        currentNode = 0;

    }
    override public void DoExitState()
    {
        ally.speed = 2;
        path = null;
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {

        base.DoFrameUpdate();

        if (ally.isAttackWithInRange == true)
        {
            ally.stateMachine.ChangeState(ally.allyAttackState);
            return;
        }// enemy in range for attack chnage to attack state
        if (ally.isArgo == false)
        {
            ally.stateMachine.ChangeState(ally.allyIdleState);
            return;
        }
        if (path == null) return;
        if (endOfPath == true) { OnReachTarget(); return; }
        if (!endOfPath && currentNode >= path.vectorPath.Count)
        {
            endOfPath = true;
            return;
        }
        Vector2 dir = ((Vector2)path.vectorPath[currentNode] - ally.RB.position).normalized;

        ally.Move(dir);
        if (Vector3.Distance(ally.RB.position, (Vector2)path.vectorPath[currentNode]) <= nextWayponitDistant)
        {
            currentNode++;
        }


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
    void OnReachTarget()
    {
        if (ally.isAttackWithInRange == false)
        {
            ally.stateMachine.ChangeState(ally.allyIdleState);
            return;
        }

        ally.stateMachine.ChangeState(ally.allyAttackState);

        return;
    }
}
