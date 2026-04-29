using System;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public Camera mainCamera { get; private set; }
    
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        this.transform.position = target.position + offset;
    }
    
    public CameraRayInfo GetMouseRaycast(Vector2 mousePosition)
    {
        CameraRayInfo rayInfo = new CameraRayInfo();
        
        Vector3 mouseReturn = Vector3.zero;
        CameraRayOutObject outObject = CameraRayOutObject.Nothing;
        bool rayHasHit = false;
        
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mouseReturn = hit.point;
            rayHasHit = true;

            if (hit.collider.gameObject.TryGetComponent<InteractableObject>(out InteractableObject interactable))
            {
                outObject = CameraRayOutObject.Interactable;
            }
            else
            {
                outObject = CameraRayOutObject.Ground;
            }
        }
        
        Debug.DrawRay(hit.point, hit.point + hit.normal, Color.deepSkyBlue,1);

        rayInfo.hasHit = rayHasHit;
        rayInfo.rayHit = mouseReturn;
        rayInfo.outType = outObject;
        rayInfo.outGameObject = hit.collider.gameObject;
        
        return rayInfo;
    }
}
