using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Move: AnyState
    {
        private bool isMouseButtonHold;
        private bool isShiftHold;
        
        public Move(PlayerStateManager stateManager, StateMachine<PlayerStateManager> state, PlayerController playerController) : base(stateManager, state, playerController)
        {
        }

        public override void HandleInput()
        {
            base.HandleInput();
            
            isMouseButtonHold = Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0);
            isShiftHold = Input.GetKey(KeyCode.LeftShift);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (state.HasState<Dead>()) return;

            if (isShiftHold)
            {
                state.ChangeState(stateManager.AttackState);
                return;
            }

            if (isMouseButtonHold)
            {
                _playerController.MoveToCursor();
                return;
            }

            if (_playerController.HasArrived())
            {
                state.ChangeState(stateManager.StandingState);
            }
        }
    }
}