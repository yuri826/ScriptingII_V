using UnityEngine;
using UI;

public class GroundItem : InteractableObject
{
    private PlayerInventory playerInventory => GamemodeBase.Instance.GetUiManager().GetPlayerInventory();
    
    [SerializeField] private InventoryItem inventoryItem;
    
    public override void OnInteract()
    {
        if (playerInventory.AddItemToInventory(inventoryItem)) Destroy(gameObject);
    }
}
