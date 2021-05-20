using JetBrains.Annotations;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using RPG.Player.States;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        public State<PlayerController> MouseMoveState;
        public State<PlayerController> AttackState;
        public State<PlayerController> StandingState;
        public State<PlayerController> DeadState;
        public StateMachine<PlayerController> fsm;

        #region monobehaviout callback

        void Start()
        {
            fsm = new StateMachine<PlayerController>();
            
            MouseMoveState = new Move(this, fsm);
            AttackState = new Attack(this, fsm);
            StandingState = new Standing(this, fsm);
            DeadState = new Dead(this, fsm);
            
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

        public void SetTargetAttack([CanBeNull] GameObject target)
        {
            if (target == null) GetComponent<Fighter>().StopAttack();
            
            if (target != null) GetComponent<Fighter>().Attack(target);
        }

        public bool OnTargetFighterHit(out RaycastHit? targetRaycastHit)
        {
            RaycastHit[] hits = Physics.RaycastAll(GetPointRay());

            targetRaycastHit = null;
            
            foreach (var hit in hits)
            {
                var target = hit.transform.GetComponent<CombatTarget>();

                if (target != null)
                {
                    targetRaycastHit = hit;
                    break;
                }
            }

            return targetRaycastHit != null;
        }

        public void MoveToCursor()
        {
            RaycastHit hit;

            bool hasHit = Physics.Raycast(GetPointRay(), out hit);

            if (hasHit)
            {
                SetTargetAttack(null);
                GetComponent<Mover>().Move(hit.point);
                
            }
        }

        private static Ray GetPointRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        
        public void AttackTarget()
        {
            RaycastHit? targetHit;
            
            OnTargetFighterHit(out targetHit);

            if (targetHit != null)
            {
                var CombatTarget = targetHit?.transform.GetComponent<CombatTarget>();
            
                SetTargetAttack(CombatTarget.gameObject);    
            }
        }
    }    
}
