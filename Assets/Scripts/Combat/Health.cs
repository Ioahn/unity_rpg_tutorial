using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        
        [SerializeField] Animator animator;

        public bool isDead = false;
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);

            if (health == 0 && !isDead)
            {
                animator.SetTrigger("dead");
                
                isDead = true;
            }
        }
    }
}