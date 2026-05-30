using UnityEngine;

[CreateAssetMenu(fileName = "ManaAdder", menuName = "Scriptable Objects/Inventory/maxManaPot")]
public class InventoryItemMaxMana : InventoryItem
{
    [Header("ManaVars")]
    [field:SerializeField] public int maxManaAdd { get; private set; }
    
    public override void Consume()
    {
        base.Consume();
        GamemodeBase.Instance.GetPlayerState().ChangeMaxMana(maxManaAdd);
    }
}
