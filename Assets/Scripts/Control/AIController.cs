using RPG.AI.States;
using RPG.Combat;
using RPG.Core;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaceDistance = 5f;
        [SerializeField] public float suspiciosTime = 5f;
        
        public State<AIController> MoveState;
        public State<AIController> AttackState;
        public State<AIController> StandingState;
        public State<AIController> DeadState;
        
        public StateMachine<AIController> fsm;
        
        #region monobehaviout callback
        private void Start()
        {
            fsm = new StateMachine<AIController>();
            
            MoveState = new Move(this, fsm);
            AttackState = new Attack(this, fsm);
            StandingState = new Standing(this, fsm);
            DeadState = new Dead(this, fsm);
            
            fsm.Initialize(StandingState);
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
        
        public void Attack()
        {
            var player = GameObject.FindWithTag("Player");
            
            GetComponent<Fighter>().Attack(player);
        }

        public void StopAttack()
        {
            GetComponent<Fighter>().StopAttack();    
        }
    }
}