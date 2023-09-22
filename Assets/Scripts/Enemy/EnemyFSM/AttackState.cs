using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyFSM
{
    /// <summary>
    /// State of enemy when it has a weapon and is at a safe distance from the player.
    /// </summary>
    
    public class AttackState : AbstractState
    {
        private NavMeshAgent agent;
        private Queue<IWeapon> weaponQueue;
        private IWeapon currentWeapon;
        public AttackState(Scratchpad _ownerData, StateMachine _ownerStateMachine) : base(_ownerData, _ownerStateMachine)
        {
            agent = (NavMeshAgent)OwnerData.Read(typeof(NavMeshAgent));
            weaponQueue = (Queue<IWeapon>)OwnerData.Read(typeof(Queue<IWeapon>));
        }

        public override void Enter()
        {
            agent.isStopped = true;
            currentWeapon = weaponQueue.Dequeue();
        }

        public override void Update(float _delta)
        {
            if (currentWeapon.Ammo <= 0)
            {
                currentWeapon = weaponQueue.Dequeue();
            }
            if (currentWeapon == null)
            {
                OwnerStateMachine.SwitchState(typeof(SearchWeaponState));
                return;
            }
            currentWeapon?.Fire();


        }

        public override void Exit()
        {
            currentWeapon = null;
            agent.isStopped = false;
        }
    }
}