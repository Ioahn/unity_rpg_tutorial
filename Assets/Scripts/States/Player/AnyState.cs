using RPG.Combat;
using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class AnyState: State<PlayerStateManager>
    {
        private bool isDead;
        protected readonly PlayerController _playerController;
        
        public AnyState(PlayerStateManager stateManager, StateMachine<PlayerStateManager> state, PlayerController playerController) : base(stateManager, state)
        {
            _playerController = playerController;
        }

        public override void HandleInput()
        {
            base.HandleInput();

            isDead = stateManager.GetComponent<Health>().isDead;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isDead)
            {
                stateManager.fsm.ChangeState(stateManager.DeadState);
            }
        }
    }
}