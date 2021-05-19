using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.AI.States
{
    public class Searching: Existance
    {
        private float timeSinceLastSawPlayer = 0; 

        
        public Searching(AIController controller, StateMachine<AIController> state) : base(controller, state)
        {
        }

        public override void HandleInput()
        {
            base.LogicUpdate();

            timeSinceLastSawPlayer += Time.deltaTime;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (timeSinceLastSawPlayer < controller.suspiciosTime)
            {
                    
            }
        }
    }
}