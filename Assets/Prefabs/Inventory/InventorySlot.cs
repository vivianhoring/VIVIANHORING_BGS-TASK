using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    Image _icon; public Image Icon => _icon;

    [SerializeField]
    Button _removeButton;
    [SerializeField]
    ItemGameEvent _onRemoveItem;

    [SerializeField]
    Button _itemButton;
    [SerializeField]
    ItemGameEvent _onUseItem;

    [SerializeField]
    TMP_Text _equippedText;

    Item _item;

    public void AddItem(Item newItem)
    {
        _item = newItem;
        _icon.sprite = _item.ItemData.Image;
        _icon.enabled = true;
        _removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _item = null;
        _icon.sprite = null;
        _icon.enabled = false;
        _removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        _onRemoveItem.Trigger(_item);
    }

    public void OnUseItem()
    {
        _onUseItem.Trigger(_item);
    }

    public void SinalizeItemEquipped(Item equippedItem)
    {
        //_equippedText.enabled = equippedItem.ItemData.Equipped;
    }
}
