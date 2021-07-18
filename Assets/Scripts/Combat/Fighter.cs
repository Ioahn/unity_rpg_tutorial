using System.Collections;
using RPG.Movement;
using UnityEngine;



namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(ComboSystem))]
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttack = 1f;
        [SerializeField] float weaponDamage = 10f;
        
        [SerializeField] private Mover mover;
        [SerializeField] Animator animator;
        [SerializeField] private ComboSystem _comboSystem;
        
        private Transform _target;
        private float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
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
        }

        public IEnumerator Attack()
        {
            while (true)
            {
                var input = AwaitInput();
                
                yield return input;
                
                var order = _comboSystem.AddToQueue((GrimoireOrder)input.Current);

                var idle = Idle(1f);
                
                yield return idle;

                if (!(bool) idle.Current)
                {
                    _comboSystem.ClearQueue();    
                }
            }
        }

        private IEnumerator Idle(float awaitTime)
        {
            float time = 0f;
            bool pressed = false;

            while (time <= awaitTime && !pressed)
            {
                time += Time.deltaTime;

                pressed = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);

                yield return null;
            }

            yield return pressed;
        }


        private IEnumerator AwaitInput()
        {
            var done = false;

            while (!done)
            {
                GrimoireOrder? result = (Input.GetMouseButtonDown(0), Input.GetMouseButtonDown(1)) switch
                {
                    (true, _) => GrimoireOrder.First,
                    (_, true) => GrimoireOrder.Second,
                    _ => null 
                };
                
                done = result != null;

                yield return result;
            }
        }
    }
}