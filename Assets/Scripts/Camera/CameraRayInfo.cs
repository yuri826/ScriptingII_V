using UnityEngine;

public class CameraRayInfo
{
    public bool hasHit { get; set; }
    public Vector3 rayHit { get; set; }
    public CameraRayOutObject outType { get; set; }
    public GameObject outGameObject { get; set; }
}
