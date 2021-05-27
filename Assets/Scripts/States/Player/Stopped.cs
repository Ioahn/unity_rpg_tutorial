using RPG.Control;
using RPG.Core;
using RPG.Movement;

namespace RPG.Player.States
{
    public class Stopped: State<PlayerStateManager>
    {
        public Stopped(PlayerStateManager stateManager, StateMachine<PlayerStateManager> state) : base(stateManager, state)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            stateManager.GetComponent<Mover>().Stop();
        }
        
        
    }
}