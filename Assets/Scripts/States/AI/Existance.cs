using RPG.Combat;
using RPG.Control;
using RPG.Core;

namespace RPG.AI.States
{
    public class Existance: State<AIController>
    {
        private bool isDead;
        public Existance(AIController controller, StateMachine<AIController> state) : base(controller, state)
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