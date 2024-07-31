using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SlotDetails_", menuName = "ScriptableObjects/SlotDetails")]
public class SlotDetails : ScriptableObject
{
    [SerializeField]
    SlotType _slotType; public SlotType SlotType => _slotType;
    Image _imageSlot; public Image ImageSlot => _imageSlot;
    Item _itemEquipped; public Item ItemEquipped => _itemEquipped;
}
