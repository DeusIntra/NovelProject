#pragma warning disable 0649

using UnityEngine;

namespace Novel.RPG
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Object/RPG/Item", order = 52)]
    public abstract class Item : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] int _buyPrice;
        [SerializeField] int _sellPrice;

        public string ItemName { get => _itemName; }
        public string Description { get => _description; }
        public Sprite Icon { get => _icon; }
        public int BuyPrice { get => _buyPrice; }
        public int SellPrice { get => _sellPrice; }

        public abstract void Use();
    }
}
