using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    HealthBar _healthBar;

    [SerializeField]
    TMP_Text _nameText;
    [SerializeField]
    TMP_Text _maxHpText;
    [SerializeField]
    TMP_Text _damageText;
    [SerializeField]
    TMP_Text _armorText;

    PlayerController _playerController;

    string _name; public int Name { get; }
    int _hp; public int HP { get; }
    int _maxHp; public int MaxHp { get; }
    int _damage; public int Damage { get; }
    int _armor; public int Armor { get; }

    void Start()
    {
        _hp = 50;
        _healthBar.UpdateHpBar(_hp);
        _playerController = GetComponent<PlayerController>();
        _name = _playerController.Name;
        _maxHp = _playerController.MaxHP;
        _damage = _playerController.Damage;
        _armor = _playerController.Armor;
        _nameText.text = _name;
        _maxHpText.text = _maxHp.ToString();
        _damageText.text = _damage.ToString();
        _armorText.text = _armor.ToString();
    }

    public void UsePotion(Item item)
    {
        if(_hp + item.ItemDetails.HpRecovery <= _playerController.PlayerDetails.MaxHP) 
        {
            _hp += item.ItemDetails.HpRecovery;
            _healthBar.UpdateHpBar(_hp);
        }
    }
}
