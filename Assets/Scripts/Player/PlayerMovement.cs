using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Player
{
    [Serializable]
    public class PlayerMovement
    {
        public NavMeshAgent agent { get; set; }
    
        public void MoveToPoint(Vector3 point)
        {
            agent.SetDestination(point);
        }
    }

}
