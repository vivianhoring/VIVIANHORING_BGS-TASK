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

    [SerializeField]
    PlayerData _playerData;

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

    public void SelectSlot(Item item, bool equipped)
    {
        foreach (Slot slot in _slots)
        {
            if(slot.SlotType == item.SlotType) 
            {
                if(equipped) EquipItem(item, slot);
                else 
                {
                    slot.UnequipItem();
                    CalculateDamageChange();
                    CalculateArmorChange();
                }
            }
        }
    }

    void EquipItem(Item item, Slot slot)
    {
        if(slot.ItemEquippedDetails == null) 
        {
            slot.EquipItem(item);
            CalculateDamageChange();
            CalculateArmorChange();
        }
        else 
        {
            slot.UnequipItem();
            slot.EquipItem(item);
            CalculateDamageChange();
            CalculateArmorChange();
            
        }
    }

    public void CalculateDamageChange()
    {
        int damage = 0;
        foreach (Slot slot in _slots)
        {
            if(slot.ItemEquippedDetails != null ) damage += slot.ItemEquippedDetails.Damage;
        }
        Debug.Log(damage);
        _playerData.ChangeItemDamage(damage);
    }

    public void CalculateArmorChange()
    {
        int armor = 0;
        foreach (Slot slot in _slots)
        {
            if(slot.ItemEquippedDetails  != null ) armor += slot.ItemEquippedDetails.Armor;
        }
        Debug.Log(armor);
        _playerData.ChangeItemArmor(armor);
    }
}
