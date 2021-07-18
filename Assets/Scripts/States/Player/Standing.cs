using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Standing: AnyState
    {
        private bool isMouseButtonPressOnce;
        private bool isMouseButtonHold;
        private bool isShiftHold;

        public Standing(PlayerStateManager stateManager, StateMachine<PlayerStateManager> state, PlayerController playerController) : base(stateManager, state, playerController)
        {
        }

        public override void Enter()
        {
            base.Enter();

            isMouseButtonPressOnce = Input.GetMouseButtonDown(0);
            isMouseButtonHold = Input.GetMouseButton(0);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            isMouseButtonPressOnce = Input.GetMouseButtonDown(0);
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
            };

            if (isMouseButtonHold || isMouseButtonPressOnce)
            {
                state.ChangeState(stateManager.MouseMoveState);
            }
        }
    }
}