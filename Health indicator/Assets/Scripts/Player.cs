using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health;

    public float HealthMaxValue { get; private set; } = 100;
    public event Action<float> HealthUpdated;

    private void Start()
    {
        _health = HealthMaxValue;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;

        HealthUpdated?.Invoke(_health);
    }

    public void Heal(float healAmount)
    {
        _health += healAmount;

        if (_health > HealthMaxValue)
            _health = HealthMaxValue;

        HealthUpdated?.Invoke(_health);
    }
}
