using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5f;
    Rigidbody2D _rb;
    Animator _animator;

    Vector2 _moviment;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
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
