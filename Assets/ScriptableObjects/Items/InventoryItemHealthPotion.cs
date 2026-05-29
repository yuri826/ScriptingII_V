using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Scriptable Objects/Inventory/HealthPot")]
public class InventoryItemHealthPotion : InventoryItem
{
    [Header("HealthVars")]
    [field:SerializeField] public int cureAmount { get; private set; }
    
    public override void Consume()
    {
        base.Consume();
        GamemodeBase.Instance.GetPlayerState().ChangeHealth(cureAmount);
    }
}
