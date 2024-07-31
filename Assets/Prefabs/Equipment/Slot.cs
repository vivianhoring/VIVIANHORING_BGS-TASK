using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    [SerializeField]
    SlotDetails _details;
    SlotType _slotType; public SlotType SlotType => _slotType;
    Image _imageSlot; public Image ImageSlot => _imageSlot;
    Item _itemEquipped; public Item ItemEquipped => _itemEquipped;

    void Awake()
    {
        _slotType = _details.SlotType;
        _imageSlot = GetComponent<Image>();
    }

    public void EquipItem(Item item)
    {
        _itemEquipped = item;
    }
    public void UnequipItem()
    {
        _itemEquipped = null;
    }
}

public enum SlotType
{
    WeaponSlot,
    HelmetSlot,
    ArmorSlot,
    BootsSlot,
    NoneSlot
}