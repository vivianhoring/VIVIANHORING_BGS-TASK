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
    ItemGameEvent _onRemoveItem;
    IGameEventListener<Item> _onRemoveItemListener;

    [SerializeField]
    int _inventorySize;
    List<Item> _inventoryList; public List<Item> InventoryList => _inventoryList;

    [SerializeField]
    ItemGameEvent _onUseItem;
    IGameEventListener<Item> _onUseItemListener;

    [SerializeField]
    ItemGameEvent _onEquippedItem;
    IGameEventListener<Item> _onEquippedItemListener;

    void OnEnable()
    {
        _onTryItemPickedUpListener = new GameEventListener<Item>(item => TryPickUpItem(item));
        _onTryItemPickedUp.RegisterListener(_onTryItemPickedUpListener);

        _onRemoveItemListener = _onRemoveItem.RegisterListener(new GameEventListener<Item>(item => RemoveItem(item)));
        _onRemoveItem.RegisterListener(_onRemoveItemListener);

        _onUseItemListener = _onUseItem.RegisterListener(new GameEventListener<Item>(item => UseItem(item)));
        _onUseItem.RegisterListener(_onUseItemListener);
    }

    void OnDisable()
    {
        _onTryItemPickedUp.UnregisterListener(_onTryItemPickedUpListener);
        _onRemoveItem.UnregisterListener(_onRemoveItemListener);
        _onUseItem.UnregisterListener(_onUseItemListener);
    }

    void Start()
    {
        _inventoryList = new List<Item>();
    }

    void TryPickUpItem(Item item)
    {
        if(item.ItemData.ItemType == ItemType.Bag) 
        { 
            _inventorySize += 3;
            _onItemPickedUp.Trigger(item);
            Debug.Log(_inventorySize);
        }
        else if(_inventoryList.Count < _inventorySize)
        {
            _inventoryList.Add(item);
            _onItemPickedUp.Trigger(item);
        }
        else
        {
            Debug.Log("Não consegue pegar o item");
        }
    }

    void RemoveItem(Item removeItem)
    {
        for (int i = _inventoryList.Count - 1; i >= 0; i--)
        {
            if (_inventoryList[i].ItemData.ItemType == removeItem.ItemData.ItemType)
            {
                _inventoryList.RemoveAt(i);
            }
        }
    }

    void UseItem(Item item)
    {
        if(item.ItemData.ItemType == ItemType.Potion) UsePotion(item);
        else if(item.ItemData.ItemType == ItemType.Armor) EquipArmor(item);
        else if(item.ItemData.ItemType == ItemType.Weapon) EquipWeapon(item);
    }

    void UsePotion(Item item)
    {
        Debug.Log("Potion consumed");
        RemoveItem(item);
    }
    void EquipArmor(Item item)
    {
        Debug.Log("Armor equipped");
        item.ItemData.Equipped = true;
    }
    void EquipWeapon(Item item)
    {
        Debug.Log("Weapon equipped");
        item.ItemData.Equipped = true;
    }
}
