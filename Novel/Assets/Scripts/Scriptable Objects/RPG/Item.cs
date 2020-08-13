#pragma warning disable 0649

using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Object/RPG/Item", order = 52)]
public abstract class Item : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] int _buyPrice;
    [SerializeField] int _sellPrice;

    public string ItemName => _itemName;
    public string Description => _description;
    public Sprite Icon => _icon;
    public int BuyPrice => _buyPrice;
    public int SellPrice => _sellPrice;

    public abstract void Use();
}
