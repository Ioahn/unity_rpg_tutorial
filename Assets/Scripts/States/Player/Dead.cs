using RPG.Control;
using RPG.Core;

namespace RPG.Player.States
{
    public class Dead: State<PlayerStateManager>
    {
        public Dead(PlayerStateManager stateManager, StateMachine<PlayerStateManager> state) : base(stateManager, state)
        {
        }
    }
}