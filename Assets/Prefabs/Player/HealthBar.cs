using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] 
    Slider _slider;

    [SerializeField] 
    PlayerData _data;

    public void UpdateHpBar(float value)
    {
        _slider.value = value;
    }
}
