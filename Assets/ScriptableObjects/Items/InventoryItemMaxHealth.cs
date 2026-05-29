using UnityEngine;

[CreateAssetMenu(fileName = "HpAdder", menuName = "Scriptable Objects/Inventory/maxHpPot")]
public class InventoryItemMaxHealth : InventoryItem
{
    [Header("HealthVars")]
    [field:SerializeField] public int maxHpAdd { get; private set; }
    
    public override void Consume()
    {
        base.Consume();
        GamemodeBase.Instance.GetPlayerState().ChangeMaxHealth(maxHpAdd);
    }
}
