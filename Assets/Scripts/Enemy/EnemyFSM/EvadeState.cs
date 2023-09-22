﻿using UnityEngine.AI;

namespace EnemyFSM
{
    public class EvadeState : AbstractState
    {
        private NavMeshAgent agent;
        public EvadeState(Scratchpad _ownerData, StateMachine _stateOwnerStateMachine) : base(_ownerData, _stateOwnerStateMachine)
        {
            agent = (NavMeshAgent)OwnerData.Read(typeof(NavMeshAgent));
        }

        public override void Enter()
        {
            
        }

        public override void Update(float _delta)
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}