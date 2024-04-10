using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GamePattern.Memento
{
    public class HotBar : Storage
    {
        public Button[] Buttons = new Button[3];
        private Memento[] _mementos = new Memento[3];
        private int lastIndex = 0;

        public void SetMemento(List<Item> items, int index)
        {
            _mementos[index].CreateMemento(items);
        }

        public List<Item> GetMemento(int index)
        {
            return _mementos[index].GetMemento();
        }

        private void Update()
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].onClick.AddListener(() =>
                {
                    SetMemento(Items,lastIndex);
                    Items = GetMemento(i);
                    lastIndex = i;
                });
            }
        }


        public class Memento
        {
            private List<Item> _items  = new List<Item>();

            public void CreateMemento(List<Item> items)
            {
                _items = items;
            }
            
            public List<Item> GetMemento()
            {
                return _items;
            }
        }

    }
}