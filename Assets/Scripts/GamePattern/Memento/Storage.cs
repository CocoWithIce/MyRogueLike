using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePattern.Memento
{
    public class Storage: MonoBehaviour
    {
        public bool StaticStorage;
        public List<Item> Items = new List<Item>();
        public List<UISlot> UISlots = new List<UISlot>();

        private UISlot _swapSlot;
        private void Start()
        {
            for(int i = 0; i < UISlots.Count; i++)
            {
                UISlots[i].UpdateUI(Items[i]);
                UISlots[i].SetupStorage(this);
                UISlots[i].SetupMouseDrag(this);
            }
        }

        public void SwapItem(UISlot slot)
        {
            if (_swapSlot == null)
            {
                _swapSlot = slot;
            }
            else if (slot == _swapSlot)
            {
                _swapSlot = null;
            }
            else
            {
                Storage sourceStorage = slot.Storage;
                int source = sourceStorage.GetIndex(slot);
                var item = sourceStorage.GetItem(source);

                Storage targetStorage = _swapSlot.Storage;
                int target = targetStorage.GetIndex(_swapSlot);
                var targetItem = targetStorage.GetItem(target);

                if (!targetStorage.StaticStorage)
                {
                    targetStorage.SetItemSlot(target, item);
                    _swapSlot.UpdateUI(item);
                }
                if (!sourceStorage.StaticStorage)
                {
                    sourceStorage.SetItemSlot(source, targetItem);
                    slot.UpdateUI(targetItem);
                }
                _swapSlot = null;
            }
        }

        public void ClearSwap()
        {
            this._swapSlot = null;
        }

        private int GetIndex(UISlot slot) => UISlots.IndexOf(slot);
        Item GetItem(int index) => Items[index];
        void SetItemSlot(int index, Item item) => Items[index] = item;

    }
}