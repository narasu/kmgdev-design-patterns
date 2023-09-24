using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyFSM
{
    /// <summary>
    /// State of enemy when it has a weapon and is at a safe distance from the player.
    /// Enemy stands still and shoots at the player.
    /// </summary>
    
    public class AttackState : AbstractState
    {
        private NavMeshAgent agent;
        private WeaponHandler weaponHandler;
        private Action<OutOfWeaponsEvent> onOutOfWeaponsEventHandler;
        public AttackState(Scratchpad _ownerData, StateMachine _ownerStateMachine) : base(_ownerData, _ownerStateMachine)
        {
            agent = (NavMeshAgent)OwnerData.Read(typeof(NavMeshAgent));
            weaponHandler = (WeaponHandler)OwnerData.Read(typeof(WeaponHandler));
            onOutOfWeaponsEventHandler = (_event) => OwnerStateMachine.SwitchState(typeof(SearchWeaponState));
            EventManager.Subscribe(typeof(OutOfWeaponsEvent), onOutOfWeaponsEventHandler);
        }

        public override void Enter()
        {
            agent.isStopped = true;
            Debug.Log("Attacking");
        }

        public override void Update(float _delta)
        {
            weaponHandler.Update(_delta);
        }

        public override void Exit()
        {
            agent.isStopped = false;
        }

        ~AttackState()
        {
            EventManager.Unsubscribe(typeof(OutOfWeaponsEvent), onOutOfWeaponsEventHandler);
        }
    }
}