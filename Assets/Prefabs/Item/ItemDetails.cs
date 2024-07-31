using UnityEngine;

[CreateAssetMenu(fileName = "ItemDetails_", menuName = "ScriptableObjects/ItemDetails")]
public class ItemDetails : ScriptableObject
{
    [SerializeField]
    string _name; public string Name => _name;
    [SerializeField]
    ItemType _itemType; public ItemType ItemType => _itemType;
    [SerializeField]
    UseType _useType; public UseType UseType => _useType;
    [SerializeField]
    SlotType _slotType; public SlotType SlotType => _slotType;
    [SerializeField]
    Sprite _image; public Sprite Image => _image;
    [SerializeField]
    int _hpRecovery; public int HpRecovery => _hpRecovery;
    [SerializeField]
    int _damage; public int Damage => _damage;
    [SerializeField]
    int _armor; public int Armor => _armor;
}
