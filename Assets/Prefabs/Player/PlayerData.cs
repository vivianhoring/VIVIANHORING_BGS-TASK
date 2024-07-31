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
    int _initialDamage; public int InitialDamage { get; }
    int _initialArmor; public int InitialArmor { get; }
    int _damage; public int Damage { get; }
    int _armor; public int Armor { get; }

    void Start()
    {
        _hp = 50;
        _healthBar.UpdateHpBar(_hp);
        _playerController = GetComponent<PlayerController>();
        _name = _playerController.Name;
        _maxHp = _playerController.MaxHP;
        _initialDamage = _playerController.Damage;
        _initialArmor = _playerController.Armor;
        _nameText.text = _name;
        _maxHpText.text = _maxHp.ToString();
        _damageText.text = _initialDamage.ToString();
        _armorText.text = _initialArmor.ToString();
    }

    public void UsePotion(Item item)
    {
        if(_hp + item.ItemDetails.HpRecovery <= _playerController.PlayerDetails.MaxHP) 
        {
            _hp += item.ItemDetails.HpRecovery;
            _healthBar.UpdateHpBar(_hp);
        }
    }
    public void ChangeItemDamage(int damage)
    {
        _damage = _initialDamage + damage;
        _damageText.text = _damage.ToString();
    }
    public void ChangeItemArmor(int armor)
    {
        _armor = _initialArmor + armor;
        _armorText.text = _armor.ToString();
    }
}
