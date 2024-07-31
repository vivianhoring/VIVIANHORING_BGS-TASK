using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    ItemGameEvent _onItemPickedUp;

    [SerializeField]
    ItemGameEvent _onTryItemPickedUp;
    IGameEventListener<Item> _onTryItemPickedUpListener;

    [SerializeField]
    int _inventorySize;
    List<Item> _inventoryList; public List<Item> InventoryList => _inventoryList;

    [SerializeField]
    BoolGameEvent _onItemEquippedChange;

    [SerializeField]
    InventoryData _inventoryData;
    [SerializeField]
    EquipmentController _equipmentController;

    [SerializeField]
    PlayerData _playerData;

    void OnEnable()
    {
        _onTryItemPickedUpListener = new GameEventListener<Item>(item => TryPickUpItem(item));
        _onTryItemPickedUp.RegisterListener(_onTryItemPickedUpListener);
    }

    void OnDisable()
    {
        _onTryItemPickedUp.UnregisterListener(_onTryItemPickedUpListener);
    }

    void Start()
    {
        _inventoryList = new List<Item>();
    }

    void TryPickUpItem(Item item)
    {
        if(item.ItemType == ItemType.Bag) 
        { 
            _inventorySize += 8;
            _onItemPickedUp.Trigger(item);
            Debug.Log(_inventorySize);
        }
        else if(_inventoryList.Count < _inventorySize)
        {
            _inventoryList.Add(item);
            _onItemPickedUp.Trigger(item);
            _inventoryData.UpdateUI();
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }

    public void RemoveItem(Item removeItem, bool inventorySlotChanged)
    {
        for (int i = _inventoryList.Count - 1; i >= 0; i--)
        {
            if (_inventoryList[i].ItemType == removeItem.ItemType)
            {
                _inventoryList.RemoveAt(i);
            }
        }
        _inventoryData.UpdateUI();
        if(!inventorySlotChanged && removeItem.UseType is UseType.Equipable) _equipmentController.SelectSlot(removeItem, false);
    }

    public void UseItem(Item item)
    {
        if(item.UseType == UseType.Consumable) UsePotion(item);
        else if(item.UseType == UseType.Equipable) UseEquipableItem(item);
    }

    void UsePotion(Item item)
    {
        _playerData.UsePotion(item);
        RemoveItem(item, false);
        _inventoryData.UpdateUI();
    }

    void UseEquipableItem(Item item)
    {
        OnEquippedItem(item);
        _inventoryData.UpdateUI();
    }

    void OnEquippedItem(Item item)
    {
        _equipmentController.SelectSlot(item, true);
    }
}
