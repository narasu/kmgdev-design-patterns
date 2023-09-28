using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyFSM
{
    /// <summary>
    /// State of enemy when it has no weapon.
    /// </summary>
    public class SearchWeaponState : AbstractState
    {
        private NavMeshAgent agent;
        private Action<WeaponSpawnedEvent> onWeaponSpawnEventHandler;
        private Action<WeaponPickedUpEvent> onWeaponPickedUpEventHandler;


        public SearchWeaponState(Scratchpad _ownerData, StateMachine _stateMachine) : 
            base(_ownerData, _stateMachine)
        {
            agent = OwnerData.Read<NavMeshAgent>();
            onWeaponPickedUpEventHandler = OnWeaponPickedUp;
        }

        public override void Enter()
        {
            EventManager.Subscribe(typeof(WeaponPickedUpEvent), onWeaponPickedUpEventHandler);
            Debug.Log("Searching for weapon...");
        }

        public override void Update(float _delta)
        {
            var searchTargets = new Collider[8];
            int n = Physics.OverlapSphereNonAlloc(agent.transform.position, 96.0f, searchTargets, 1 << 8);
            if (n > 0)
            {
                Vector3 targetPosition = searchTargets[0].transform.position;
                float currentDistance = Vector3.Distance(agent.transform.position, targetPosition);

                for (int i = 1; i < n && i < searchTargets.Length; i++)
                {
                    Vector3 nextTargetPosition = searchTargets[i].transform.position;
                    float newDistance = Vector3.Distance(agent.transform.position, nextTargetPosition);

                    if (newDistance < currentDistance)
                    {
                        targetPosition = nextTargetPosition;
                        currentDistance = newDistance;
                    }
                }

                agent.SetDestination(targetPosition);
            }
        }

        public override void Exit()
        {
            EventManager.Unsubscribe(typeof(WeaponPickedUpEvent), onWeaponPickedUpEventHandler);
        }

        private void OnWeaponPickedUp(WeaponPickedUpEvent _event)
        {
            Debug.Log("Weapon picked up");
            OwnerStateMachine.SwitchState(typeof(AttackState));
        }
    }
}