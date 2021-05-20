using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RPG.Helpers;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        private const float waypointGizmoRad = 0.3f;
        private void OnDrawGizmos()
        {
            Array.ForEach(GetComponentsInChildren<Transform>(), (child, i, list) =>
            {
                if (child == list.First()) return; 
                
                Gizmos.DrawSphere(child.position, waypointGizmoRad);

                Gizmos.DrawLine(child.position, list.ElementAt(child == list.Last() ? 1 : i + 1).position);
            });
        }

        public IEnumerator<Vector3> WayPoints()
        {
            IEnumerable<Transform> waypoints = GetComponentsInChildren<Transform>();

            var i = 1;

            while (true)
            {
                yield return waypoints.ElementAt(i).position;
                
                i = i == waypoints.Count() - 1 ? 1 : i + 1;
            }
        } 
    }
}