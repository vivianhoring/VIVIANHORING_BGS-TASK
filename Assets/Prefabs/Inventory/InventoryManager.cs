using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    Canvas _inventoryCanvas;
    [SerializeField]
    Inventory _inventory;
    [SerializeField]
    Transform _itemsParent;
    [SerializeField]
    BoolGameEvent _onInventoryActive;
    IGameEventListener<bool> _onInventoryActiveListener;

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
        _onInventoryActive.RegisterListener(_onInventoryActiveListener);
    }

    void OnDisable()
    {
        _onInventoryActive.UnregisterListener(_onInventoryActiveListener);
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
            if(i<_inventory.InventoryList.Count)
            {
                _slots[i].AddItem(_inventory.InventoryList[i]); 
            } else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
