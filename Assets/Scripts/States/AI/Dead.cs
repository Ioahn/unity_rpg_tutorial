using RPG.Control;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.AI.States
{
    public class Dead: State<AIController>
    {
        public Dead(AIController controller, StateMachine<AIController> state) : base(controller, state)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateManager.GetComponent<NavMeshAgent>().enabled = false;
            stateManager.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}