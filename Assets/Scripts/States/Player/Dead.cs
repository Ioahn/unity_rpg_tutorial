using RPG.Control;
using RPG.Core;

namespace RPG.Player.States
{
    public class Dead: State<PlayerController>
    {
        public Dead(PlayerController controller, StateMachine<PlayerController> state) : base(controller, state)
        {
        }
    }
}