using System;
using System.Collections;
using JetBrains.Annotations;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float attackSpeed = 3f;
        
        private IEnumerator _attackCourutine;


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
                GetComponent<Mover>().Move(hit.point);
                
            }
        }

        public void StopMovement()
        {
            GetComponent<Mover>().Stop();       
        }
        
        public bool HasArrived()
        {
            return GetComponent<Mover>().HasArrived();
        }

        private static Ray GetPointRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        public void Attack()
        {
            _attackCourutine = GetComponent<Fighter>().Attack();
            
            StartCoroutine(_attackCourutine);
        }

        public void StopAttack()
        {
            StopCoroutine(_attackCourutine);    
        }
    }
}