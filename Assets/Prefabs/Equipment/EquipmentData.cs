using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentData : MonoBehaviour
{
    [SerializeField]
    Canvas _equipmentCanvas;
    [SerializeField]
    Transform _itemsParent;

    [SerializeField]
    BoolGameEvent _onEquipmentActive;
    IGameEventListener<bool> _onEquipmentActiveListener;

    bool _equipmentOn;

    void Start()
    {
        _equipmentCanvas.enabled = _equipmentOn;
    }

    void OnEnable()
    {
        _onEquipmentActiveListener = _onEquipmentActive.RegisterListener(new GameEventListener<bool>((bool equipmentOn) => SetActiveequipment(equipmentOn)));
    }

    void OnDisable()
    {
        _onEquipmentActive.UnregisterListener(_onEquipmentActiveListener);
    }

    void SetActiveequipment(bool equipmentOn)
    {
        _equipmentOn = equipmentOn;
        _equipmentCanvas.enabled = _equipmentOn;
    }
}
