using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    [SerializeField]
    Canvas _inventoryCanvas;
    [SerializeField]
    InventoryController _inventoryController;
    [SerializeField]
    Transform _itemsParent;

    [SerializeField]
    BoolGameEvent _onInventoryActive;
    IGameEventListener<bool> _onInventoryActiveListener;

    [SerializeField]
    ItemGameEvent _onRemoveItem;
    IGameEventListener<Item> _onRemoveItemListener;

    [SerializeField]
    ItemGameEvent _onUseItem;
    IGameEventListener<Item> _onUseItemListener;

    bool _inventoryOn;
    InventorySlot[] _slots;

    void Start()
    {
        _inventoryCanvas.enabled = _inventoryOn;
        _slots = _itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void OnEnable()
    {
        _onInventoryActiveListener = _onInventoryActive.RegisterListener(new GameEventListener<bool>((bool inventoryOn) => SetActiveInventory(inventoryOn)));

        _onRemoveItemListener = _onRemoveItem.RegisterListener(new GameEventListener<Item>((_) => UpdateUI()));
        _onRemoveItem.RegisterListener(_onRemoveItemListener);

        _onUseItemListener = _onUseItem.RegisterListener(new GameEventListener<Item>((_) => UpdateUI()));
        _onUseItem.RegisterListener(_onUseItemListener);
    }

    void OnDisable()
    {
        _onInventoryActive.UnregisterListener(_onInventoryActiveListener);
        _onRemoveItem.UnregisterListener(_onRemoveItemListener);
        _onUseItem.UnregisterListener(_onRemoveItemListener);
    }

    void SetActiveInventory(bool inventoryOn)
    {
        _inventoryOn = inventoryOn;
        _inventoryCanvas.enabled = _inventoryOn;
        if (_inventoryOn) UpdateUI();
    }

    void UpdateUI()
    {
        for(int i = 0; i < _slots.Length; i++)
        {
            //_slots[i].GetComponent<InventorySlot>().SinalizeItemEquipped(_inventoryController.InventoryList[i]);
            if(i<_inventoryController.InventoryList.Count)
            {
                _slots[i].AddItem(_inventoryController.InventoryList[i]); 
            } else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
