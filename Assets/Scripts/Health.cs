using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;

    protected float _health;

    public event Action<float> HealthChanged;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;

    protected virtual void Start()
    {
        _health = _maxHealth;
    }

    protected virtual void Update()
    {
        if (_health <= 0)
            Death();
    }

    protected virtual void ReduceHealth(float health)
    {
        _health -= health;
        HealthChanged?.Invoke(_health);
    }

    protected virtual void RestoreHealth(float health)
    {
        _health = _health + health > _maxHealth ? _maxHealth : _health += health;
        HealthChanged?.Invoke(_health);
    }

    protected abstract void Death();
}
