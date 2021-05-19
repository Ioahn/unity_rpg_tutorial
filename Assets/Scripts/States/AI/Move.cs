using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.AI.States
{
    public class Move: Standing
    {
        public Move(AIController controller, StateMachine<AIController> state) : base(controller, state)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }
    }
}