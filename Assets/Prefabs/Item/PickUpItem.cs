using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    ItemGameEvent _onItemPickedUp;
    CircleCollider2D _circleCollider;

    Item _item;

    void Awake()
    {
        _item = GetComponent<Item>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        CheckIfPlayerIsInside();
    }

    void CheckIfPlayerIsInside()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_circleCollider.bounds.center, _circleCollider.radius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                if(Input.GetButtonDown("Action"))
                {
                    _onItemPickedUp.Trigger(_item);
                }
            }
        }
    }
}
