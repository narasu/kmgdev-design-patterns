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

        public AttackState(Scratchpad _ownerData, StateMachine _ownerStateMachine) :
            base(_ownerData, _ownerStateMachine)
        {
            agent = OwnerData.Read<NavMeshAgent>();
            weaponHandler = OwnerData.Read<WeaponHandler>();
            onOutOfWeaponsEventHandler = _event => OwnerStateMachine.SwitchState(typeof(SearchWeaponState));
        }

        public override void Enter()
        {
            agent.ResetPath();
            Debug.Log("Attacking!");
            EventManager.Subscribe(typeof(OutOfWeaponsEvent), onOutOfWeaponsEventHandler);
        }

        public override void Update(float _delta)
        {
            weaponHandler.Update(_delta);
            if (agent.hasPath)
            {
                OwnerStateMachine.SwitchState(typeof(EvadeState));
            }
        }

        public override void Exit()
        {
            EventManager.Unsubscribe(typeof(OutOfWeaponsEvent), onOutOfWeaponsEventHandler);
        }
    }
}