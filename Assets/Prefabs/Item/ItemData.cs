using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData_", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject, IItem
{
    [SerializeField]
    string _name; public string Name => _name;
    [SerializeField]
    string _type; public string Type => _type;
}
