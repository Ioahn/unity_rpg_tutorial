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

            MakeAttack();

            stateManager.LastTimeSawPlayer = 0;
        }

        private void MakeAttack()
        {
            var player = GameObject.FindWithTag("Player");
            
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
            
            if (!chase)
            {

                state.ChangeState(stateManager.SuspiciousState);    
            }
        }
    }
}