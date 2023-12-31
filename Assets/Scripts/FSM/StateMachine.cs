using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Dictionary<Type, IState> states = new();
    private IState currentState;

    public StateMachine(params IState[] _states)
    {
        foreach (IState s in _states)
        {
            states.TryAdd(s.GetType(), s);
        }
    }

    public void Update(float _delta)
    {
        currentState?.Update(_delta);
    }

    public void AddState(IState _state)
    {
        states.TryAdd(_state.GetType(), _state);
    }

    public void SwitchState(Type _nextState)
    {
        currentState?.Exit();
        currentState = states[_nextState];
        currentState?.Enter();
    }
}