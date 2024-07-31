using System.Collections.Generic;
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

    void Start()
    {
        _slots = new List<Slot>
        {
            _weaponSlot,
            _helmetSlot,
            _armorSlot,
            _bootsSlot
        };
    }

    public void SelectSlot(Item item, bool equip)
    {
        foreach (Slot slot in _slots)
        {
            if(slot.SlotType == item.SlotType) 
            {
                if(equip) EquipItem(item, slot);
                else slot.UnequipItem();
            }
        }
    }

    void EquipItem(Item item, Slot slot)
    {
        if(slot.ItemEquippedDetails == null) 
        {
            slot.EquipItem(item);
        }
        else 
        {
            slot.UnequipItem();
            slot.EquipItem(item);
        }
    }
}
