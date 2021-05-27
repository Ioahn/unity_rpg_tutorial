using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Move: Standing
    {
        public Move(PlayerStateManager stateManager, StateMachine<PlayerStateManager> state, PlayerController playerController) : base(stateManager, state, playerController)
        {
        }
        
        public override void Enter()
        {
            base.Enter();

            _playerController.MoveToCursor();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_playerController.HasArrived())
            {
                state.ChangeState(stateManager.StandingState);
            }
        }
    }
}