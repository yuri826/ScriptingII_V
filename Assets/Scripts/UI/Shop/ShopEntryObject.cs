using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopEntryObject : MonoBehaviour
    {
        public InventoryItem item { get; set; }
        private ShopMenuManager menuManager;

        [Header("Components")] 
        [SerializeField] private Image BG;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Image itemIconImage;

        public void Init(InventoryItem inventoryItem, ShopMenuManager menuManager)
        {
            item = inventoryItem;
            this.menuManager = menuManager;
            
            BG.color = new Vector4(0, 0, 0, 0.8f);

            nameText.text = item.Name;
            priceText.text = item.BuyPrice.ToString();
            itemIconImage.sprite = item.Icon;
        }

        public void ShowInfo()
        {
            menuManager.ShowInfoPanel(item, this);
        }

        public void Deselect()
        {
            BG.color = new Vector4(0, 0, 0, 0.8f);
        }

        public void Select()
        {
            BG.color = Color.white;
        }
    }
}