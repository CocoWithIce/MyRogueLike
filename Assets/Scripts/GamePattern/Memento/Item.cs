using UnityEngine;

namespace GamePattern.Memento
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 2)]
    public class Item: ScriptableObject
    {
        public string Name;
        public Sprite Icon;
    }
}