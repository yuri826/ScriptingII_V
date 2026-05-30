
using System.Collections.Generic;
using FMODUnity;
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
        private ShopEntryObject currentObject;

        [Header("Audio")] 
        [SerializeField] private EventReference sfxbuy;

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

            foreach (Transform entry in itemParent)
            {
                Destroy(entry.gameObject);
            }
            
            shopEntries.Clear();
            
            for (int i = 0; i < shopData.itemsToSell.Length; i++)
            {
                ShopEntryObject entry = Instantiate(shopEntryPrefab, itemParent).GetComponent<ShopEntryObject>();
                entry.Init(shopData.itemsToSell[i], this);
                shopEntries.Add(entry);
            }
        
            itemListPanel.SetActive(true);
        }

        public void TryBuyItem()
        {
            if ((currentObject.item.BuyPrice <= GamemodeBase.Instance.GetPlayerState().money)
                && (GamemodeBase.Instance.GetUiManager().GetPlayerInventory().AddItemToInventory(currentObject.item)))
            {
                GamemodeBase.Instance.GetPlayerState().ChangeMoney(-currentObject.item.BuyPrice);
                AudioManager.Instance.PlaySFX(sfxbuy);
            }
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

            currentObject = entry;
            entry.Select();
        }

        public void HideMenu()
        {
            GamemodeBase.Instance.GetUiManager().CloseShop();
            Hide();
        }

        private void Hide()
        {
            itemDescriptionPanel.SetActive(false);
            itemListPanel.SetActive(false);
        }
    }
}

