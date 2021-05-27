using System;
using RPG.Core;
using RPG.Player.States;
using UnityEngine;

namespace RPG.Control
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerStateManager : MonoBehaviour
    {
        public State<PlayerStateManager> MouseMoveState;
        public State<PlayerStateManager> AttackState;
        public State<PlayerStateManager> StandingState;
        public State<PlayerStateManager> DeadState;
        public State<PlayerStateManager> StoppedState;
        
        public StateMachine<PlayerStateManager> fsm;

        #region monobehaviout callback

        void Start()
        {
            
            InitializeFSM();
        }

        private void InitializeFSM()
        {
            var playerController = GetComponent<PlayerController>();
            
            fsm = new StateMachine<PlayerStateManager>();

            MouseMoveState = new Move(this, fsm, playerController);
            AttackState = new Attack(this, fsm, playerController);
            StandingState = new Standing(this, fsm, playerController);
            DeadState = new Dead(this, fsm);
            StoppedState = new Stopped(this, fsm);

            fsm.Initialize(StandingState);
        }

        void OnGUI()
        {
            GUI.Label(new Rect( 0, Screen.height - 20, 300, 20 ),  fsm.CurrentState.ToString());    
        }
        
        private void Update()
        {
            fsm.CurrentState.HandleInput();
            
            fsm.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            fsm.CurrentState.PhysicsUpdate();
        }

        #endregion
    }    
}
