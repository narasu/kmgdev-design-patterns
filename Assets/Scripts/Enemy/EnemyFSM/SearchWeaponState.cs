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
        

        public SearchWeaponState(Scratchpad _ownerData, StateMachine _stateMachine) : base(_ownerData, _stateMachine)
        {
            agent = (NavMeshAgent)OwnerData.Read(typeof(NavMeshAgent));
            //onWeaponSpawnEventHandler = GetNewPickupTarget;
            onWeaponPickedUpEventHandler = OnWeaponPickedUp;
            
        }

        public override void Enter()
        {
            // GotoNearestPickup();
            // EventManager.Subscribe(typeof(WeaponSpawnedEvent), onWeaponSpawnEventHandler);
            EventManager.Subscribe(typeof(WeaponPickedUpEvent), onWeaponPickedUpEventHandler);
            Debug.Log("Searching for weapon...");
        }

        public override void Update(float _delta)
        {
            float currentDistance;
            var searchTargets = new Collider[32];
            int n = Physics.OverlapSphereNonAlloc(agent.transform.position, 96.0f, searchTargets, 1 << 8);
            if (n > 0)
            {
                Vector3 targetPosition = searchTargets[0].transform.position;
                currentDistance = Vector3.Distance(agent.transform.position, targetPosition);
                
                for (int i = 1; i < n && i < searchTargets.Length; i++)
                {
                    if (Vector3.Distance(agent.transform.position, searchTargets[i].transform.position) < currentDistance)
                    {
                        targetPosition = searchTargets[i].transform.position;
                    }
                }

                agent.SetDestination(targetPosition);
            }
        }

        public override void Exit()
        {
            // EventManager.Unsubscribe(typeof(WeaponSpawnedEvent), onWeaponSpawnEventHandler);
            EventManager.Unsubscribe(typeof(WeaponPickedUpEvent), onWeaponPickedUpEventHandler);
        }

        /*private void GetNewPickupTarget(WeaponSpawnedEvent _event)
        {
            searchTargets.Add(_event.SpawnedWeapon);
            GotoNearestPickup();
        }*/

        private void GotoNearestPickup()
        {
            /*if (searchTargets.Count > 0)
            {
                Vector3 targetPosition = searchTargets[0].position;
                currentDistance = Vector3.Distance(agent.transform.position, targetPosition);
                
                for (int i = 1; i < searchTargets.Count; i++)
                {
                    if (Vector3.Distance(agent.transform.position, searchTargets[i].position) < currentDistance)
                    {
                        targetPosition = searchTargets[i].position;
                    }
                }

                agent.SetDestination(targetPosition);
            }*/
        }

        private void OnWeaponPickedUp(WeaponPickedUpEvent _event)
        {
            // searchTargets.Remove(_event.PickupTransform);
            Debug.Log("Weapon picked up");
            OwnerStateMachine.SwitchState(typeof(AttackState));
        }
    }
}