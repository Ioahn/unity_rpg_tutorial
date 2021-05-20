using System;
using RPG.AI.States;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] public float chaceDistance = 5f;
        [SerializeField] public float suspiciosTime = 5f;
        [SerializeField] public float waypointTolerance = 1.0f;
        [SerializeField] public float patrolDelay = 3.0f;
        [SerializeField] public PatrolPath path;

        internal Fighter fighter;
        internal Mover mover;
        
        public State<AIController> PatrolState;
        public State<AIController> AttackState;
        public State<AIController> ObserveState;
        public State<AIController> DeadState;
        public State<AIController> SuspiciousState;
        
        public StateMachine<AIController> fsm;

        internal Vector3 guardPosition;
        
        public float LastTimeSawPlayer { set; get; }
        
        #region monobehaviout callback
        private void Start()
        {
            guardPosition = transform.position;
            
            fighter = GetComponent<Fighter>();
            mover = GetComponent<Mover>();
            
            StateInit();
        }

        private void StateInit()
        {
            fsm = new StateMachine<AIController>();

            PatrolState = new Patrol(this, fsm);
            AttackState = new Attack(this, fsm);
            ObserveState = new Observe(this, fsm);
            DeadState = new Dead(this, fsm);
            SuspiciousState = new Suspicious(this, fsm);

            fsm.Initialize(ObserveState);
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

        public bool IsChase()
        {
            var player = GameObject.FindWithTag("Player");
            
            var distance = Vector3.Distance(player.transform.position, transform.position);

            return distance < chaceDistance;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaceDistance);
        }
    }
}