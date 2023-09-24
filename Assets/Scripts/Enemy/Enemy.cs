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
        ObjectData.Write( GetComponent<NavMeshAgent>() );

        var weaponHandler = new WeaponHandler();
        ObjectData.Write( weaponHandler );

        stateMachine = new StateMachine(this);
        stateMachine.AddState( new AttackState(ObjectData, stateMachine) );
        stateMachine.AddState( new EvadeState(ObjectData, stateMachine) );
        stateMachine.AddState( new SearchWeaponState(ObjectData, stateMachine) );
        stateMachine.SwitchState( typeof(SearchWeaponState) );
    }

    private void Update()
    {
        stateMachine.Update(Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider _other)
    {
        var weaponData = (WeaponData) _other.GetComponent<IPickup>()?.PickUp();

        if (weaponData != null)
        {
            EventManager.Invoke( new WeaponPickedUpEvent(weaponData, _other.transform) );
        }
    }
}
