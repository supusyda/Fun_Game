using System.Collections;
using System.Collections.Generic;

using Pathfinding;
using UnityEngine;

public class Crew : AllyBase
{
    // Start is called before the first frame update
    [SerializeField] private AIllyOnComandSOBase allyOnComandSOBase;
    [SerializeField] private AllyChasingSOBase allyChasingSOBase;
    public AIllyOnComandSOBase AllyOnComandSOBase;
    public AllyOnComandMoveState AllyOnComand;
    public AllyChasingState AllyChasing;
    public AllyChasingSOBase AllyChasingSOBase;
    public Seeker seeker;

    protected override void Awake()
    {
        seeker = GetComponent<Seeker>();
        AllyOnComandSOBase = Instantiate(allyOnComandSOBase);
        AllyOnComandSOBase.Init(this, transform, gameObject);
        AllyOnComand = new AllyOnComandMoveState(stateMachine, this);


        AllyChasingSOBase = Instantiate(allyChasingSOBase);
        AllyChasingSOBase.Init(this, transform, gameObject);
        AllyChasing = new AllyChasingState(stateMachine, this);


        base.Awake();

    }
    public void ChangeStateToComand(Vector3 dir)
    {
        // if (stateMachine.CurrentState == AllyOnComand) return;
        stateMachine.ChangeState(AllyOnComand);

    }
    private void OnDrawGizmosSelected()
    {
        if (target != null)
        {

            Gizmos.DrawLine(transform.position, target.position);
        }
        else
        {
            Gizmos.DrawLine(transform.position, transform.position);

        }
    }
}
