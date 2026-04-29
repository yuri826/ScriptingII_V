using System;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] private GameObject itemEntryPrefab;
        
        [Header("Panels")] 
        
        [Header("ItemInfo")] 
        [SerializeField] private GameObject itemPanel;
        [SerializeField] private TextMeshProUGUI itemTitle;
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemInfo;
    
        [Header("Grid")] 
        [SerializeField] private GameObject gridPanel;

        private List<InventorySlot> inventorySlots = new List<InventorySlot>();

        private void Awake()
        {
            foreach (Transform child in gridPanel.transform)
            {
                inventorySlots.Add(child.GetComponent<InventorySlot>());
            }

            HideInventory();
        }

        public void ActivateInventory()
        {
            itemPanel.SetActive(false);
            gridPanel.SetActive(true);
        }

        public void ActivateItemPanel(InventoryItem item)
        {
            itemTitle.text = item.Name;
            itemImage.sprite = item.Image;
            itemInfo.text = item.Info;
        
            itemPanel.SetActive(true);
        }

        public void HideItemPanel()
        {
            itemPanel.SetActive(false);
        }

        public bool AddItemToInventory(InventoryItem item)
        {
            InventorySlot inventoryItem = null;
                
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i].isTaken) continue;
                
                inventoryItem = inventorySlots[i];
                break;
            }

            if (inventoryItem is null) return false;
            
            DraggableInventoryObject inventoryEntry = 
                Instantiate(itemEntryPrefab, inventoryItem.gameObject.transform)
                    .GetComponent<DraggableInventoryObject>();

            inventoryItem.isTaken = true;

            inventoryEntry.inventoryItem = item;

            return true;
        }
    
        public void HideInventory()
        {
            itemPanel.SetActive(false);
            gridPanel.SetActive(false);
        }
    }
}

