using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderHealthViewer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _isSmoothnesBar;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = _player.HealthMaxValue;

        ChangeSliderValue(_player.HealthMaxValue);
    }

    private void OnEnable()
    {
        _player.HealthUpdate += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _player.HealthUpdate -= ChangeSliderValue;
    }

    private void ChangeSliderValue(float health)
    {
        if (_isSmoothnesBar)
        {
            StartCoroutine(SmoothCahnge(health));
        }
        else
        {
            _slider.value = health;
        }
    }

    private IEnumerator SmoothCahnge(float health)
    {
        float maxDelta = 0.15f;

        while (_slider.value != health)
        {
            float changedHealth = Mathf.MoveTowards(_slider.value, health, maxDelta);
            _slider.value = changedHealth;

            yield return null;
        }
        yield break;
    }
}
