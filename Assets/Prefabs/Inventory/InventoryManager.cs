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
    private List<InventoryImage> _inventoryImages;
    [SerializeField]
    EmptyGameEvent _onInventoryActive;
    IEmptyGameEventListener _onInventoryActiveListener;

    void Start()
    {
        _inventoryCanvas.enabled = false;
    }

    void OnEnable()
    {
        _onInventoryActiveListener = new EmptyGameEventListener(SetActiveInventory);
        _onInventoryActive.RegisterListener(_onInventoryActiveListener);
    }

    void OnDisable()
    {
        _onInventoryActive.UnregisterListener(_onInventoryActiveListener);
    }

    void SetActiveInventory()
    {
        _inventoryCanvas.enabled = true;
        PopulateInventory();
    }

    void PopulateInventory()
    {
        if (_inventory.InventoryList.Count == 0) return;
        int count = 0;
        foreach (var item in _inventory.InventoryList)
        {
            _inventoryImages[count].ItemSprite = item.ItemData.Image;
            count++;
        }
    }
}
