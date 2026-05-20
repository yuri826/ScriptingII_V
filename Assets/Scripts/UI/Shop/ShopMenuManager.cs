using UnityEngine;

namespace UI
{
    public class ShopMenuManager : MonoBehaviour
    {
        [Header("MenuData")]
        [SerializeField] private Transform itemParent;
        [SerializeField] private GameObject shopEntryPrefab;

        [Header("Panels")] 
        [SerializeField] private GameObject itemListPanel;
        [SerializeField] private GameObject itemDescriptionPanel;
    
        public void ShowMenu(ShopData shopData)
        {
            itemDescriptionPanel.SetActive(false);
        
            for (int i = 0; i < shopData.itemsToSell.Length; i++)
            {
                ShopEntryObject entry = Instantiate(shopEntryPrefab, itemParent).GetComponent<ShopEntryObject>();
                entry.Init(shopData.itemsToSell[i]);
            }
        
            itemListPanel.SetActive(true);
        }
    }
}

