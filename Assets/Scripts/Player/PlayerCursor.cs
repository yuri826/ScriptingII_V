using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCursor : MonoBehaviour
    {
        private PlayerLogic playerPawn => mainGamemode.GetPlayer();
        private GamemodeBase mainGamemode;
    
        [SerializeField] private CameraLogic camerota;
    
        private void Start()
        {
            mainGamemode = GamemodeBase.Instance;
        }

        public void OnLClick(Vector2 mousePos)
        {
            //CameraRayInfo rayInfo = camerota.GetMouseRaycast(mousePos);
            CameraRayInfo rayInfo = playerPawn.GetPlayerCamera().GetMouseRaycast(mousePos);
        
            //if (rayInfo is null) throw new NullReferenceException("No hay rayo de cámara");
        
            if (!rayInfo.hasHit) return;
        
            switch (rayInfo.outType)
            {
                case CameraRayOutObject.Ground:
                    playerPawn.MoveToPoint(rayInfo.rayHit);
                    break;
            
                case CameraRayOutObject.Interactable:
                    InteractableObject interactable = rayInfo.outGameObject.GetComponent<InteractableObject>();
                    print(interactable);
                    playerPawn.MoveToInteractable(rayInfo.rayHit, interactable);
                    break;
            }
        }
    } 
}