using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerLogic : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private CameraLogic playerCamera;

        private Coroutine interactableRoutine;

        public void Awake()
        {
            playerMovement.agent = this.agent;
        }

        public void MoveToPoint(Vector3 point)
        {
            playerMovement.MoveToPoint(point);
        }
    
        public void MoveToInteractable(Vector3 point,InteractableObject interactable)
        {
            playerMovement.MoveToPoint(point);
        
            if (interactableRoutine is not null) StopCoroutine(interactableRoutine);
            interactableRoutine = StartCoroutine(CheckIfDestinationReached(interactable));
        }
    
        public CameraLogic GetPlayerCamera()
        {
            return playerCamera;
        }
    
        private IEnumerator CheckIfDestinationReached(InteractableObject interactable)
        {
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);
            interactable.OnInteract();
        }
    }
}
