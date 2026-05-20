using UnityEngine;

public class GroundMoney : MonoBehaviour
{
    [field: SerializeField] public int moneyAmount { get; set; }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GamemodeBase.Instance.GetPlayerState().ChangeMoney(moneyAmount);
            Destroy(gameObject);
        }
    }
}
