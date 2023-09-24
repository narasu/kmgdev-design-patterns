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
        public EvadeState(Scratchpad _ownerData, StateMachine _stateOwnerStateMachine) : base(_ownerData, _stateOwnerStateMachine)
        {
            agent = (NavMeshAgent)OwnerData.Read(typeof(NavMeshAgent));
        }

        public override void Enter()
        {
            Debug.Log("Evading!");
        }

        public override void Update(float _delta)
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}