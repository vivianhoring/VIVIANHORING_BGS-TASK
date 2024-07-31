using UnityEngine;

public interface ItemInterface
{
    public string Name { get; }
    public Sprite Image { get; }
    public int HpRecovery { get; }
    public int Damage { get; }
    public int Armor { get; }

    public ItemType ItemType { get; }
    public UseType UseType { get; }
    public SlotType SlotType { get; }
    public void PickUp(Item item);
}

public enum ItemType
{
    Weapon,
    Helmet,
    Armor,
    Boots,
    Potion,
    Bag
}

public enum UseType
{
    Consumable,
    Equipable,
    None
}
