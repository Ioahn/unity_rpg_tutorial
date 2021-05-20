using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.AI.States
{
    public class Suspicious: Observe
    {
        public Suspicious(AIController controller, StateMachine<AIController> state) : base(controller, state)
            {
            }

         public override void Enter()
         {
             base.Enter();
             
             
         }

         public override void HandleInput()
         {
             base.HandleInput();

             controller.LastTimeSawPlayer += Time.deltaTime;
         }

         public override void LogicUpdate()
         {
             base.LogicUpdate();

             if (controller.LastTimeSawPlayer > controller.suspiciosTime)
             {
                state.ChangeState(controller.ObserveState);      
             }
         }
    }
}