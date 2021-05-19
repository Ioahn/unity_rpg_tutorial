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

            controller.StopAttack();
            
            controller.GetComponent<NavMeshAgent>().enabled = false;
            controller.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}