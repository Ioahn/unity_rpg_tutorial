using RPG.Combat;
using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Existance: State<PlayerController>
    {
        private bool isDead;
        
        public Existance(PlayerController controller, StateMachine<PlayerController> state) : base(controller, state)
        {
        }

        public override void HandleInput()
        {
            base.HandleInput();

            isDead = controller.GetComponent<Health>().isDead;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isDead)
            {
                controller.fsm.ChangeState(controller.DeadState);
            }
        }
    }
}