using System.Collections;
using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.AI.States
{
    public class Patrol: Observe
    {
        private Vector3 _nextPosition;
        private IEnumerator _coroutine;
        private float _waitingTime;
        
        public Patrol(AIController controller, StateMachine<AIController> state) : base(controller, state)
        {
            _nextPosition = controller.guardPosition;

            if (controller.path != null)
            {
                _coroutine = controller.path.WayPoints();
            }
        }

        public override void Enter()
        {
            base.HandleInput();

            if (_coroutine != null)
            {
                GoToNextPosition();    
            }

            _waitingTime = 0;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_coroutine == null)
            {
                GoToNextPosition();

                return;
            }
            
            if (AtWaypoint())
            {
                if (_waitingTime < controller.patrolDelay)
                {
                    _waitingTime += Time.deltaTime;
                    return;
                }

                _waitingTime = 0;
                
                CycleWaypoint();

                GoToNextPosition();
            }
            
        }

        private void GoToNextPosition()
        {
            controller.mover.Move(_nextPosition);
        }
        
        private Vector3 GetCurrentWaypoint()
        {
            return (Vector3) _coroutine.Current;
        }

        private void CycleWaypoint()
        {
            if (_coroutine.MoveNext())
            {
                _nextPosition = GetCurrentWaypoint();
            }
        }

        private bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(controller.transform.position, _nextPosition);

            return distanceToWaypoint < controller.waypointTolerance;
        }
    }
}