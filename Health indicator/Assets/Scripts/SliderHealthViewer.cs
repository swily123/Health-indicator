using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderHealthViewer : MonoBehaviour
{
    [SerializeField] private Player _player;

    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = _player.HealthMaxValue;

        ChangeSliderValue(_player.HealthMaxValue);
    }

    private void OnEnable()
    {
        _player.HealthUpdated += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _player.HealthUpdated -= ChangeSliderValue;
    }

    protected virtual void ChangeSliderValue(float health)
    {
        _slider.value = health;
    }
}
