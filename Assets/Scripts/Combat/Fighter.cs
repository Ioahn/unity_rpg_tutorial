using System;
using System.Collections;
using JetBrains.Annotations;
using RPG.Movement;
using UnityEngine;



namespace RPG.Combat
{
    enum GrimuarPosition
    {
        Left, Right
    }
    
    interface ISpell
    {
        float GetDamage();

        float GetAnimationDuration();

    }

    interface IInvetory
    {
        Grimuar GetGrimuar();
    }

    interface IGrimuar
    {
        Spell GetSpell(int i);
    }
    
    public class Inventory: IInvetory
    {
        public Grimuar GetGrimuar()
        {
            return new Grimuar();
        }
    }


    public class Spell: ISpell
    {
        public float GetDamage()
        {
            return 20f;
        }

        public float GetAnimationDuration()
        {
            return 1f;
        }
    }


    public class Grimuar: IGrimuar
    {
        public Spell GetSpell(int i)
        {
            return new Spell();    
        }
    }

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

                var grimuar = GetGrimuar((GrimuarPosition)input.Current);

                var spell = grimuar.GetSpell(1);

                yield return new WaitForSeconds(spell.GetAnimationDuration());
                
                Debug.Log("lalal");
            }

        }

        private Grimuar GetGrimuar(GrimuarPosition grimuarPosition)
        {
            return new Inventory().GetGrimuar();
        }

        private IEnumerator AwaitInput()
        {
            var done = true;

            while (done)
            {
                GrimuarPosition? result = (Input.GetMouseButtonDown(0), Input.GetMouseButtonDown(1)) switch
                {
                    (true, _) => GrimuarPosition.Left,
                    (_, true) => GrimuarPosition.Right,
                    _ => null 
                };
                
                done = result == null;

                yield return result;
            }
        }
    }
}