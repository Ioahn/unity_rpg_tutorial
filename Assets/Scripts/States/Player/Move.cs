using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Move: Standing
    {
        public Move(PlayerController controller, StateMachine<PlayerController> state) : base(controller, state)
        {
        }

        public override void Enter()
        {
            base.Enter();

            controller.MoveToCursor();
        }
    }
}