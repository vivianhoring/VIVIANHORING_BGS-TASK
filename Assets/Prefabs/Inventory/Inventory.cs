using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    ItemGameEvent _onItemPickedUp;
    [SerializeField]
    ItemGameEvent _onTryItemPickedUp;
    IGameEventListener<Item> _onTryItemPickedUpListener;

    [SerializeField]
    int _inventorySize;
    List<Item> _inventoryList; public List<Item> InventoryList => _inventoryList;

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
}
