
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopMenuManager : MonoBehaviour
    {
        [Header("MenuData")]
        [SerializeField] private Transform itemParent;
        [SerializeField] private GameObject shopEntryPrefab;
        private List<ShopEntryObject> shopEntries = new List<ShopEntryObject>();

        [Header("Panels")] 
        [SerializeField] private GameObject itemListPanel;
        [SerializeField] private GameObject itemDescriptionPanel;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemType;
        [SerializeField] private TextMeshProUGUI itemDescription;
        [SerializeField] private TextMeshProUGUI itemPrice;
        [SerializeField] private Image itemImage;
    
        public void ShowMenu(ShopData shopData)
        {
            itemDescriptionPanel.SetActive(false);
        
            for (int i = 0; i < shopData.itemsToSell.Length; i++)
            {
                ShopEntryObject entry = Instantiate(shopEntryPrefab, itemParent).GetComponent<ShopEntryObject>();
                entry.Init(shopData.itemsToSell[i], this);
                shopEntries.Add(entry);
            }
        
            itemListPanel.SetActive(true);
        }

        public void ShowInfoPanel(InventoryItem item, ShopEntryObject entry)
        {
            for (int i = 0; i < shopEntries.Count; i++)
            {
                shopEntries[i].Deselect();
            }
            
            itemName.text = item.Name;
            itemType.text = item.Type;
            itemDescription.text = item.Info;
            itemPrice.text = item.BuyPrice.ToString();
            itemDescriptionPanel.SetActive(true);

            entry.Select();
        }

        public void HideMenu()
        {
            itemDescriptionPanel.SetActive(false);
            itemListPanel.SetActive(true);
        }
    }
}

