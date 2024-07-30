using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    ItemGameEvent _onItemPickedUp;
    IGameEventListener<Item> _onItemPickedUpListener;
    [SerializeField]
    ItemDetails _itemDetails; public ItemDetails ItemDetails => _itemDetails;

    void OnEnable()
    {
        _onItemPickedUpListener = new GameEventListener<Item>(item => PickUp(item));
        _onItemPickedUp.RegisterListener(_onItemPickedUpListener);
    }

    void OnDisable()
    {
        _onItemPickedUp.UnregisterListener(_onItemPickedUpListener);
    }

    void PickUp(Item item)
    {
        Destroy(item.gameObject, 0.5f);
    }
}
