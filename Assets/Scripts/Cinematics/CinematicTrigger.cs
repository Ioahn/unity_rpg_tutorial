using System;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<PlayableDirector>().Play();    
            }
        }
    }
}