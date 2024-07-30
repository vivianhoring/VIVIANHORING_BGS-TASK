using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData_", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject, IItem
{
    [SerializeField]
    string _name; public string Name => _name;
    [SerializeField]
    ItemType _itemType; public ItemType ItemType => _itemType;
    [SerializeField]
    Sprite _image; public Sprite Image => _image;
}
