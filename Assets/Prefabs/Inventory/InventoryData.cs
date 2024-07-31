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

    public void UpdateUI()
    {
        for(int i = 0; i < _slots.Length; i++)
        {
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
