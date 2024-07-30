using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentController : MonoBehaviour
{
    [SerializeField]
    EquipmentData _equipmentData;
    List<Item> _equippedItems;

    public void SelectEquipment(Item item)
    {
        if(item.ItemDetails.ItemType is ItemType.Weapon) EquipItem(item, ItemType.Weapon);
        else if(item.ItemDetails.ItemType is ItemType.Helmet) EquipItem(item, ItemType.Helmet);
        else if(item.ItemDetails.ItemType is ItemType.Armor) EquipItem(item, ItemType.Armor);
        else if(item.ItemDetails.ItemType is ItemType.Boots) EquipItem(item, ItemType.Boots);
    }

    void EquipItem(Item item, ItemType type)
    {
        if(!EquippedItemTypeIsNull(_equippedItems, type))
        {
            foreach(Item equippedItem in _equippedItems)
            {
                if(equippedItem.ItemDetails.ItemType == type) 
                {
                    equippedItem.ItemDetails.Equipped = false;
                    _equippedItems.Remove(equippedItem);
                }
            }
        }
        _equippedItems.Add(item);
        item.ItemDetails.Equipped = true;
        _equipmentData.UpdateUI(_equippedItems);
    }

    bool EquippedItemTypeIsNull(List<Item> equippedItems, ItemType type)
    {
        foreach(Item item in equippedItems)
        {
            if (item.ItemDetails.ItemType == type) return false;
        }
        return true;
    }
}
