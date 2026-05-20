using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopEntryObject : MonoBehaviour
{
    private InventoryItem item;

    [Header("Components")] 
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Image itemIconImage;

    public void Init(InventoryItem inventoryItem)
    {
        item = inventoryItem;

        nameText.text = item.Name;
        priceText.text = item.BuyPrice.ToString();
        itemIconImage.sprite = item.Icon;
    }
}
