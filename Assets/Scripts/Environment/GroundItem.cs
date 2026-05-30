using System;
using UnityEngine;
using UI;

public class GroundItem : InteractableObject
{
    private PlayerInventory playerInventory => GamemodeBase.Instance.GetUiManager().GetPlayerInventory();
    
    [SerializeField] private InventoryItem inventoryItem;
    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponentInChildren<SpriteRenderer>();
        spr.sprite = inventoryItem.GroundSprite;
    }

    public override void OnInteract()
    {
        if (playerInventory.AddItemToInventory(inventoryItem)) Destroy(gameObject);
    }
}
