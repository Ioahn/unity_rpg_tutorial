using System;
using RPG.Control;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicsControlRemover : MonoBehaviour
    {
        private void Start()
        {
          GetComponent<PlayableDirector>().played += OnPlayed;
          GetComponent<PlayableDirector>().stopped += OnStopped;
        }
        
        private void OnPlayed(PlayableDirector obj)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            var playerController = player.GetComponent<PlayerController>();
            
            playerController.fsm.ChangeState(playerController.StoppedState);    
        }
        
        private void OnStopped(PlayableDirector obj)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            var playerController = player.GetComponent<PlayerController>();
            
            playerController.fsm.ChangeState(playerController.StandingState);
        }
    }
}