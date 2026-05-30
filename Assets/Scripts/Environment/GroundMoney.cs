using FMODUnity;
using UnityEngine;

public class GroundMoney : MonoBehaviour
{
    [field: SerializeField] public int moneyAmount { get; set; }
    [SerializeField] private EventReference sfxAcquire;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(sfxAcquire);
            GamemodeBase.Instance.GetPlayerState().ChangeMoney(moneyAmount);
            Destroy(gameObject);
        }
    }
}
