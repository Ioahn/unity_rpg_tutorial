using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Player.States
{
    public class Attack: AnyState
    {
        private bool targetIsKilled;
        private bool isShiftHold;
        private bool isAttackBegan = false;
        
        public Attack(PlayerStateManager stateManager, StateMachine<PlayerStateManager> state, PlayerController playerController) : base(stateManager, state, playerController)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _playerController.StopMovement();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            
            isShiftHold = Input.GetKey(KeyCode.LeftShift);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (state.HasState<Dead>()) return;

            if (isShiftHold && !isAttackBegan)
            {
                isAttackBegan = true;
                _playerController.Attack();
            }
            else if (!isShiftHold)
            {
                isAttackBegan = false;
                _playerController.StopAttack();
                
                state.ChangeState(stateManager.StandingState);
            }
        }
    }
}