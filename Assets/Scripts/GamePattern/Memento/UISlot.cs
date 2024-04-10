using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GamePattern.Memento
{
    public class UISlot: MonoBehaviour
    {
        [FormerlySerializedAs("Image")] public Image image;
        public Storage Storage;
        private MouseDrag _mouseDrag;

        public void UpdateUI(Item item)
        {
            if (item == null)
            {
                image = null;
            }
            else
            {
                image.sprite = item.Icon;
            }
        }

        public void SetupStorage(Storage storage)
        {
            this.Storage = storage;
        }

        public void SetupMouseDrag(Storage storage)
        {
            _mouseDrag = gameObject.GetOrAddComponent<MouseDrag>();
            _mouseDrag.SetupStorage(storage, this);
        }
    }
}