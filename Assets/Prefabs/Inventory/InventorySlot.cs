using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    Image _icon; public Image Icon => _icon;

    [SerializeField]
    Button _removeButton;
    [SerializeField]
    Button _itemButton;
    [SerializeField]
    TMP_Text _equippedText;
    [SerializeField]
    InventoryController _inventoryController;

    Item _item;

    public void AddItem(Item newItem)
    {
        _item = newItem;
        _icon.sprite = _item.Image;
        _icon.enabled = true;
        _removeButton.interactable = true;
        _itemButton.interactable = true;
    }

    public void ClearSlot()
    {
        _item = null;
        _icon.sprite = null;
        _icon.enabled = false;
        _removeButton.interactable = false;
        _itemButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        _inventoryController.RemoveItem(_item);
    }

    public void OnUseItem()
    {
        _inventoryController.UseItem(_item);
    }
}
