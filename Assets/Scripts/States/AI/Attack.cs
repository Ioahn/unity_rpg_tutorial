using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.AI.States
{
    public class Attack: Existance
    {
        private bool chase;
        
        public Attack(AIController controller, StateMachine<AIController> state) : base(controller, state)
        {
        }

        public override void Enter()
        {
            base.Enter();

            controller.Attack();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            chase = controller.IsChase();

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (state.HasState<Dead>()) return;
            
            if (!chase)
            {
                controller.StopAttack();
                state.ChangeState(controller.StandingState);    
            }
        }
    }
}