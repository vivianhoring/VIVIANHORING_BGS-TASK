using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [SerializeField]
    Slot _weaponSlot;
    [SerializeField]
    Slot _helmetSlot;
    [SerializeField]
    Slot _armorSlot;
    [SerializeField]
    Slot _bootsSlot;

    List<Slot> _slots;

    public void SelectSlot(Item item)
    {
        if(_slots == null) PopulateSlots();
        foreach (Slot slot in _slots)
        {
            if(slot.SlotType == item.SlotType) EquipItem(item, slot);
        }
    }

    void EquipItem(Item item, Slot slot)
    {
        if(slot.ItemEquipped == null) slot.EquipItem(item);
        else 
        {
            slot.UnequipItem();
            slot.EquipItem(item);
        }
        UnityEngine.Debug.Log(_weaponSlot.SlotType + ": " + _weaponSlot.ItemEquipped);
        UnityEngine.Debug.Log(_helmetSlot.SlotType + ": " + _helmetSlot.ItemEquipped);
        UnityEngine.Debug.Log(_helmetSlot.SlotType + ": " + _helmetSlot.ItemEquipped);
        UnityEngine.Debug.Log(_bootsSlot.SlotType + ": " + _bootsSlot.ItemEquipped);
    }

    
    void PopulateSlots()
    {
        _slots.Add(_weaponSlot);
        _slots.Add(_helmetSlot);
        _slots.Add(_armorSlot);
        _slots.Add(_bootsSlot);
    }
}
