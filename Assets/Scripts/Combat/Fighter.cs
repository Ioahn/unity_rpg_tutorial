using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttack = 1f;
        [SerializeField] float weaponDamage = 10f;
        
        [SerializeField] private Mover mover;
        [SerializeField] Animator animator;
        
        private Transform _target;
        private float timeSinceLastAttack = 0;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            if (_target != null)
            {
                bool isInRange = Vector3.Distance(transform.position, _target.position) < weaponRange;

                if (isInRange)
                {
                    mover.Stop();
                    AttackBehaviour();
                }
                else
                {
                    mover.Move(_target.position);
                }
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttack)
            {
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
            
            transform.LookAt(_target);
        }
        
        // Animation Event
        private void Hit()
        {
            if (_target == null) return;
            
            var targetHealth = _target.GetComponent<Health>();
            
            targetHealth.TakeDamage(weaponDamage);

            if (targetHealth.isDead)
            {
                StopAttack();
            }
        }

        public void Attack(GameObject combatTarget)
        {
            if (!combatTarget.GetComponent<Health>().isDead)
            {
                _target = combatTarget.transform;       
            }
        }
        
        public void StopAttack()
        {
            _target = null;
        }
    }
}