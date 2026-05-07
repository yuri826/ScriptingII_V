using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Player
{
    [Serializable]
    public class PlayerMovement
    {
        public Rigidbody rb { get; set; }
        public NavMeshAgent agent { get; set; }
        
        public void MoveToPoint(Vector3 point)
        {
            agent.SetDestination(point);
        }

        public void Move(Vector2 inputDir, float walkSpeed)
        {
            Vector3 movementDirWorld = new Vector3(inputDir.x, 0, inputDir.y).normalized;
            Vector3 movementDir = Quaternion.AngleAxis(45, Vector3.up) * movementDirWorld;
            rb.linearVelocity = movementDir * walkSpeed;
        }

        public void StopMove()
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

}
