using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerDetails_", menuName = "ScriptableObjects/PlayerDetails")]
public class PlayerDetails : ScriptableObject
{
    [SerializeField]
    string _name; public string Name => _name;
    [SerializeField]
    int _maxHP; public int MaxHP => _maxHP;
    [SerializeField]
    int _damage; public int Damage => _damage;
    [SerializeField]
    int _armor; public int Armor => _armor;
}
