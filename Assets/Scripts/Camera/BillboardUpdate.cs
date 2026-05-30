using UnityEngine;

public class BillboardUpdate : MonoBehaviour
{
    private void Update()
    {
        this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }
}
