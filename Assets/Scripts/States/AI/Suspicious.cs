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

             stateManager.LastTimeSawPlayer += Time.deltaTime;
         }

         public override void LogicUpdate()
         {
             base.LogicUpdate();

             if (stateManager.LastTimeSawPlayer > stateManager.suspiciosTime)
             {
                state.ChangeState(stateManager.ObserveState);      
             }
         }
    }
}