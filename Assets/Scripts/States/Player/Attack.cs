using RPG.Combat;
using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Attack: Existance
    {
        private bool isMouseButtonHold;
        private bool targetIsKilled;
        public Attack(PlayerController controller, StateMachine<PlayerController> state) : base(controller, state)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            isMouseButtonHold = false;
            
            controller.AttackTarget();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            isMouseButtonHold = Input.GetMouseButtonDown(0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (state.HasState<Dead>()) return;
            
            if (isMouseButtonHold && !controller.OnTargetFighterHit(out _))
            {
                state.ChangeState(controller.StandingState);
            }
        }
    }
}