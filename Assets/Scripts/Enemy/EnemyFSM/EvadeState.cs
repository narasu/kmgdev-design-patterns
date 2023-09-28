using UnityEngine;
using UnityEngine.AI;

namespace EnemyFSM
{
    /// <summary>
    /// State of enemy when it has a weapon but the player is too close. 
    /// </summary>
    public class EvadeState : AbstractState
    {
        private NavMeshAgent agent;

        public EvadeState(Scratchpad _ownerData, StateMachine _ownerStateMachine) : 
            base(_ownerData, _ownerStateMachine)
        {
            agent = OwnerData.Read<NavMeshAgent>();
        }

        public override void Enter()
        {
            Debug.Log("Evading!");
        }

        public override void Update(float _delta)
        {
            if (!agent.hasPath)
            {
                OwnerStateMachine.SwitchState(typeof(AttackState));
            }
        }

        public override void Exit() { }
    }
}