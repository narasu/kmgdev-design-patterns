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
    public StateMachine FSM { get; private set; }
    

    private void Awake()
    {
        ObjectData = new Scratchpad();
        ObjectData.Create( GetComponent<NavMeshAgent>() );

        var weaponHandler = new WeaponHandler();
        ObjectData.Create(weaponHandler);

        FSM = new StateMachine();
        FSM.AddState( new AttackState(ObjectData, FSM) );
        FSM.AddState( new EvadeState(ObjectData, FSM) );
        FSM.AddState( new SearchWeaponState(ObjectData, FSM) );
        FSM.SwitchState( typeof(SearchWeaponState) );
    }

    private void Update()
    {
        FSM.Update(Time.deltaTime);
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
