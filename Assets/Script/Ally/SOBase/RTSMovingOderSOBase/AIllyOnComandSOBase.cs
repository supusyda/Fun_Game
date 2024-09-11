using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
[CreateAssetMenu(fileName = "Ally-Comand-Move", menuName = "Ally/Comand/Move")]
public class AIllyOnComandSOBase : StateSOBase
{
    protected Crew ally;
    Vector3 movingDir;
    Vector3 randTargetPos;
    Seeker seeker;
    Path path;
    int currentNode = 0;
    bool endOfPath = false;
    float nextWayponitDistant = .2f;

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
        endOfPath = false;
        ally.animator.Play("Walk");
        randTargetPos = RTSControl.Instance.targetPos + (Vector3)Random.insideUnitCircle.normalized;
        seeker.StartPath(ally.RB.position, randTargetPos, onCompleCreatePath);
        // movingDir = randTargetPos - ally.transform.position;
        // movingDir.Normalize();

    }

    private void onCompleCreatePath(Path p)
    {
        if (p.error) return;
        path = p;
        currentNode = 0;

    }

    override public void DoExitState()
    {
        base.DoExitState();
    }
    override public void DoFrameUpdate()
    {
        // RTSControl.
        // Vector3 movingDir = RTSControl.Instance.GetRandTargetPos() - ally.transform.position;
        
        if (path == null) return;
        if (endOfPath == true) { ally.stateMachine.ChangeState(ally.allyIdleState); return; }
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

}
