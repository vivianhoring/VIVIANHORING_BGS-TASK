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
    BoolGameEvent _onItemEquippedChange;
    IGameEventListener<bool> _onItemEquippedChangeListener;

    bool _inventoryOn;
    bool _itemEquippedChange;
    InventorySlot[] _slots;

    void Start()
    {
        _inventoryCanvas.enabled = _inventoryOn;
        _slots = _itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void OnEnable()
    {
        _onInventoryActiveListener = _onInventoryActive.RegisterListener(new GameEventListener<bool>((bool inventoryOn) => SetActiveInventory(inventoryOn)));
        _onItemEquippedChangeListener = new GameEventListener<bool>(itemEquippedChange => SetEquippedFlagChange(itemEquippedChange));
        _onItemEquippedChange.RegisterListener(_onItemEquippedChangeListener);
    }

    void OnDisable()
    {
        _onInventoryActive.UnregisterListener(_onInventoryActiveListener);
        _onItemEquippedChange.UnregisterListener(_onItemEquippedChangeListener);
    }

    void SetActiveInventory(bool inventoryOn)
    {
        _inventoryOn = inventoryOn;
        _inventoryCanvas.enabled = _inventoryOn;
        if (_inventoryOn) UpdateUI();
    }

    public void UpdateUI()
    {
        for(int i = 0; i < _slots.Length; i++)
        {
            if(i<_inventoryController.InventoryList.Count)
            {
                _slots[i].AddItem(_inventoryController.InventoryList[i]); 
                _slots[i].SetEquippedFlag(_itemEquippedChange);
            } else
            {
                _slots[i].ClearSlot();
            }
        }
    }

    void SetEquippedFlagChange(bool itemEquippedFlag)
    {
        _itemEquippedChange = itemEquippedFlag;
    }
}
