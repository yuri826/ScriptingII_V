using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    private void Start()
    {
        this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }
}
