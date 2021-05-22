using RPG.Control;
using RPG.Core;
using RPG.Movement;

namespace RPG.Player.States
{
    public class Stopped: State<PlayerController>
    {
        public Stopped(PlayerController controller, StateMachine<PlayerController> state) : base(controller, state)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            controller.GetComponent<Mover>().Stop();
        }
    }
}