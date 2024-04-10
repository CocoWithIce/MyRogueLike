using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GamePattern.Memento
{
    public class MouseDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Storage storage;
        public  UISlot slot;
        GameObject dragObject;

        public void SetupStorage(Storage storage, UISlot slot)
        {
            this.storage = storage;
            this.slot = slot;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            storage.SwapItem(this.slot);
            dragObject = new GameObject("Drag" + this.slot.name);
            var image = dragObject.AddComponent<Image>();
            image.sprite = this.slot.image.sprite;
            image.raycastTarget = false;
            
            dragObject.transform.SetParent(storage.transform);
            dragObject.transform.localScale = Vector3.one;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (dragObject != null)
            {
                dragObject.transform.position = Input.mousePosition;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject is GameObject targetObject)
            {
                var targetSlot = targetObject.GetComponent<UISlot>();
                if (targetSlot != null)
                {
                    storage.SwapItem(targetSlot);
                    EventSystem.current.SetSelectedGameObject(targetObject);
                }
            }
            storage.ClearSwap();

            if (dragObject != null)
            {
                Destroy(dragObject);
            }
        }
    }
}