using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float _movementSpeed = 5f;

    [SerializeField]
    PlayerDetails _playerDetails; public PlayerDetails PlayerDetails => _playerDetails;

    [SerializeField] 
    BoolGameEvent _onInventoryActive;
    [SerializeField] 
    BoolGameEvent _onEquipmentActive;

    Rigidbody2D _rb;
    Animator _animator;
    Vector2 _moviment;
    bool _inventoryActive;
    bool _equipmentActive;

    string _name; public string Name => _name;
    int _maxHP; public int MaxHP => _maxHP;
    int _damage; public int Damage => _damage;
    int _armor; public int Armor => _armor;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _name = _playerDetails.Name;
        _maxHP = _playerDetails.MaxHP;
        _damage = _playerDetails.Damage;
        _armor = _playerDetails.Armor;
    }

    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            _inventoryActive = !_inventoryActive;
            _onInventoryActive.Trigger(_inventoryActive);
        }
        if(Input.GetButtonDown("Equipment"))
        {
            _equipmentActive = !_equipmentActive;
            _onEquipmentActive.Trigger(_equipmentActive);
        }
        Moviment();
    }

    void Moviment()
    {
        _moviment.x = Input.GetAxisRaw("Horizontal");
        _moviment.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", _moviment.x);
        _animator.SetFloat("Vertical", _moviment.y);
        _animator.SetFloat("Speed", _moviment.sqrMagnitude);

    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moviment.normalized * _movementSpeed * Time.fixedDeltaTime);
    }

}
