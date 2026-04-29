using System;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class DraggableInventoryObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private PlayerInventory playerInventory => GamemodeBase.Instance.GetUiManager().GetPlayerInventory();
        public Transform currentParent { get; set; }
        private Image image;
        
        [field: SerializeField] public InventoryItem inventoryItem { get; set; }

        private void Awake()
        {
            currentParent = transform.parent;
            image = GetComponent<Image>();
            transform.position = currentParent.transform.position;
        }

        private void Start()
        {
            image.sprite = inventoryItem.InventorySprite;
        }

        #region Dragging

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            playerInventory.HideItemPanel();
            
            currentParent.GetComponent<InventorySlot>().isTaken = false;
            
            currentParent = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(currentParent);
            transform.position = currentParent.position;
            image.raycastTarget = true;
        }
    
        #endregion

        public void OnPointerClick(PointerEventData eventData)
        {
            playerInventory.ActivateItemPanel(inventoryItem);
        }
    }
}
