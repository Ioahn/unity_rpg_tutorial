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

            controller.LastTimeSawPlayer = 0;
        }

        private void MakeAttack()
        {
            var player = GameObject.FindWithTag("Player");

            controller.fighter.Attack(player);
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
                controller.fighter.StopAttack(); 
                
                state.ChangeState(controller.SuspiciousState);    
            }
        }
    }
}