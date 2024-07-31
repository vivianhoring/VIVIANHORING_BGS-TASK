using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public interface ItemInterface
{
    public string Name { get; }
    public Sprite Image { get; }
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
