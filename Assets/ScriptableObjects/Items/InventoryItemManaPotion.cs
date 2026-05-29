using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Scriptable Objects/Inventory/ManaPot")]
public class InventoryItemManaPotion : InventoryItem
{
    [Header("ManaVars")]
    [field:SerializeField] public int cureAmount { get; private set; }
    
    public override void Consume()
    {
        base.Consume();
        GamemodeBase.Instance.GetPlayerState().ChangeMana(cureAmount);
    }
}
