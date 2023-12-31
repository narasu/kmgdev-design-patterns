using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState : IState
{
    public Scratchpad OwnerData { get; }
    protected StateMachine OwnerStateMachine { get; }

    protected AbstractState(Scratchpad _ownerData, StateMachine _ownerStateMachine)
    {
        OwnerData = _ownerData;
        OwnerStateMachine = _ownerStateMachine;
    }

    public abstract void Enter();
    public abstract void Update(float _delta);
    public abstract void Exit();
}