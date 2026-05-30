using System;
using FMODUnity;
using UnityEngine;
using UI;

public class GroundItem : InteractableObject
{
    private PlayerInventory playerInventory => GamemodeBase.Instance.GetUiManager().GetPlayerInventory();
    
    [SerializeField] private InventoryItem inventoryItem;
    private SpriteRenderer spr;
    
    [SerializeField] private EventReference sfxPick;

    private void Awake()
    {
        spr = GetComponentInChildren<SpriteRenderer>();
        spr.sprite = inventoryItem.GroundSprite;
    }

    public override void OnInteract()
    {
        if (playerInventory.AddItemToInventory(inventoryItem))
        {
            AudioManager.Instance.PlaySFX(sfxPick);
            Destroy(gameObject);
        }
    }
}
