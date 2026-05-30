using UnityEngine;

public class DetachParticles : MonoBehaviour
{
    [SerializeField] private int time = 1;
    void Start()
    {
        this.transform.parent = null;
        Destroy(gameObject,time);
    }
}
