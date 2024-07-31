using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ItemInterface
{
    [SerializeField]
    ItemDetails _details; public ItemDetails ItemDetails => _details;
    [SerializeField]
    ItemGameEvent _onItemPickedUp;
    IGameEventListener<Item> _onItemPickedUpListener;
    string _name; public string Name => _name;
    ItemType _itemType; public ItemType ItemType => _itemType;
    UseType _useType; public UseType UseType => _useType;
    SlotType _slotType; public SlotType SlotType => _slotType;
    Sprite _image; public Sprite Image => _image;
    public bool ItemIsEquipped;
    
    void Awake()
    {
        _name = _details.Name;
        _itemType = _details.ItemType;
        _image = _details.Image;
        _useType = _details.UseType;
    }

    void OnEnable()
    {
        _onItemPickedUpListener = new GameEventListener<Item>(item => PickUp(item));
        _onItemPickedUp.RegisterListener(_onItemPickedUpListener);
    }

    void OnDisable()
    {
        _onItemPickedUp.UnregisterListener(_onItemPickedUpListener);
    }

    public void PickUp(Item item)
    {
        Destroy(item.gameObject, 0.5f);
    }
}
