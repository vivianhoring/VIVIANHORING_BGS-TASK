using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    [SerializeField]
    SlotDetails _details;
    [SerializeField]
    Image _imageSlot; public Image ImageSlot => _imageSlot;
    SlotType _slotType; public SlotType SlotType => _slotType;
    ItemDetails _itemEquippedDetails; public ItemDetails ItemEquippedDetails => _itemEquippedDetails;
    Item _itemEquipped;

    void Awake()
    {
        _slotType = _details.SlotType;
    }

    public void EquipItem(Item item)
    {
        _itemEquippedDetails = item.ItemDetails;
        _imageSlot.enabled = true;
        _imageSlot.sprite = item.Image;
        item.ItemIsEquipped = true;
        _itemEquipped = item;
    }
    public void UnequipItem()
    {
        _itemEquipped.ItemIsEquipped = false;
        _itemEquippedDetails = null;
        _imageSlot.enabled = false;
        _imageSlot.sprite = null;
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