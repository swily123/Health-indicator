using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health;

    public float HealthMaxValue { get; private set; } = 100;
    public event Action<float> HealthUpdate;

    private void Start()
    {
        _health = HealthMaxValue;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;

        HealthUpdate?.Invoke(_health);
    }

    public void Heal(float healAmount)
    {
        _health += healAmount;

        if (_health > HealthMaxValue)
            _health = HealthMaxValue;

        HealthUpdate?.Invoke(_health);
    }
}
