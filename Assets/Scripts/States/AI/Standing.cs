using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.AI.States
{
    public class Standing: Existance
    {
        private bool chase;
        
        public Standing(AIController controller, StateMachine<AIController> state) : base(controller, state)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            chase = stateManager.IsChase();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (state.HasState<Dead>()) return;
            
            if (chase)
            {
                state.ChangeState(stateManager.AttackState);
            }      
        }
    }
}