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
        [SerializeField] private Rigidbody rb;
        [SerializeField] private CameraLogic playerCamera;

        [SerializeField] private float walkSpeed;
        
        [field:SerializeField] public Transform castPoint { get; private set; }

        private Coroutine interactableRoutine;

        public void Awake()
        {
            playerMovement.agent = this.agent;
            playerMovement.rb = this.rb;
        }

        private void Start()
        {
            GamemodeBase.Instance.GetInputManager().inputReader.onMove += OnMove;
            GamemodeBase.Instance.GetInputManager().inputReader.onStopMovement += OnMove;
        }

        private void OnMove(Vector2 inputDir)
        {
            if (interactableRoutine is not null) StopCoroutine(interactableRoutine);
            if (agent.hasPath) agent.isStopped = true;
            
            // if (inputDir != Vector2.zero) this.transform.rotation = 
            //     Quaternion.LookRotation(new Vector3(inputDir.x,0,inputDir.y), Vector3.up) 
            //     * Quaternion.Euler(0,90,0);
            
            playerMovement.Move(inputDir, walkSpeed);
        }
    
        public void MoveToInteractable(Vector3 point,InteractableObject interactable)
        {
            playerMovement.MoveToPoint(point);
            agent.isStopped = false;
            
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
