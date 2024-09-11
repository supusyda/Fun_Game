using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBase
{
    // Start is called before the first frame update

    public StateBase CurrentState { get; set; }
    public bool isBlockToOtherState = false;
    public void Init(StateBase startingState)
    {
        CurrentState = startingState;
        CurrentState.EnterState();
    }
    public void ChangeState(StateBase newState)
    {
        if (isBlockToOtherState == true) return;
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }
}
