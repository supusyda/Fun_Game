using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
  public  EnemyStateBase CurrentEnemyState { get; set; }
    public void Init(EnemyStateBase startingState)
    {
        CurrentEnemyState = startingState;
        CurrentEnemyState.EnterState();
    }
    public void ChangeState(EnemyStateBase newState)
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();
    }
}
