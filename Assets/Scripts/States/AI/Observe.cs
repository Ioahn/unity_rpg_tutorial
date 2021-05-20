﻿using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.AI.States
{
    public class Observe: Existance
    {
        private bool chase;

        public Observe(AIController controller, StateMachine<AIController> state) : base(controller, state)
        {
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

            if (chase)
            {
                state.ChangeState(controller.AttackState);
            }
            
            if (state.HasState<Observe>())
            {
                state.ChangeState(controller.PatrolState);
            }
        }
    }
}