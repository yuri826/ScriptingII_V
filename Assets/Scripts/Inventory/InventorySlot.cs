using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        public bool isTaken { get; set; } = false;

        private void Awake()
        {
            if (transform.childCount > 0) isTaken = true;
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            isTaken = true;
            print("slotYES");
            eventData.pointerDrag.GetComponent<DraggableInventoryObject>().currentParent = this.transform;
        }
    }
}