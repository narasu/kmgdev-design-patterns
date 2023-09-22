using System;
using System.Collections;
using System.Collections.Generic;
using EnemyFSM;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IStateRunner
{
    public Scratchpad ObjectData { get; private set; }
    private StateMachine stateMachine;
    

    private void Awake()
    {
        ObjectData = new Scratchpad();
        ObjectData.Write(transform);
        ObjectData.Write(GetComponent<NavMeshAgent>());
        ObjectData.Write(new Queue<IWeapon>());

        stateMachine = new StateMachine(this);
        stateMachine.AddState(new AttackState(ObjectData, stateMachine));
        stateMachine.AddState(new EvadeState(ObjectData, stateMachine));
        stateMachine.AddState(new SearchWeaponState(ObjectData, stateMachine));
        stateMachine.SwitchState(typeof(EvadeState));
    }

    private void Update()
    {
        stateMachine.Update(Time.deltaTime);
    }
}
