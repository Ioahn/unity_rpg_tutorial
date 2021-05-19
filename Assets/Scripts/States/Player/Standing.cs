using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Standing: Existance
    {
        private bool isMouseButtonPressOnce;
        private bool isMouseButtonHold;
        public Standing(PlayerController controller, StateMachine<PlayerController> state) : base(controller, state)
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
            isMouseButtonHold = Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (state.HasState<Dead>()) return;
            
            if (isMouseButtonPressOnce)
            {
                if (controller.OnTargetFighterHit(out _)) state.ChangeState(controller.AttackState);
            }

            if (isMouseButtonHold)
            {
                state.ChangeState(controller.MouseMoveState);
            }

            if (!isMouseButtonPressOnce && !isMouseButtonHold)
            {
                state.ChangeState(controller.StandingState);    
            }
        }
    }
}