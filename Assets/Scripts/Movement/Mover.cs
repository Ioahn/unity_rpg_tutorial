using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] NavMeshAgent nav;
        [SerializeField] Animator animator;

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = nav.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);

            float speed = localVelocity.z;

            animator.SetFloat("forwardSpeed", speed);
        }

        public void Move(Vector3 destination)
        {
            nav.destination = destination;
            nav.isStopped = false;
        }

        public void Stop()
        {
            nav.isStopped = true;
        }
    }
}
