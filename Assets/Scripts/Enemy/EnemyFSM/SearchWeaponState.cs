using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyFSM
{
    public class SearchWeaponState : AbstractState
    {
        private NavMeshAgent agent;
        private Action<Transform> onWeaponSpawnEventHandler;
        
        public SearchWeaponState(Scratchpad _ownerData, StateMachine _stateMachine) : base(_ownerData, _stateMachine)
        {
        }

        public override void Enter()
        {
            agent = (NavMeshAgent)OwnerData.Read(typeof(NavMeshAgent));
            onWeaponSpawnEventHandler = GetWeapon;
            EventManager.Subscribe(typeof(WeaponSpawnedEvent), onWeaponSpawnEventHandler);
        }

        public override void Update(float _delta)
        {
            
        }

        public override void Exit()
        {
            
        }

        private void GetWeapon(Transform _target)
        {
            
        }
    }
}