using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

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

    protected virtual void ReduceHealth(float damage)
    {
        if (damage >= 0)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);
        }
    }

    protected virtual void RestoreHealth(float heal)
    {
        if (heal >= 0)
        {
            _health = _health + heal > _maxHealth ? _maxHealth : _health += heal;
            HealthChanged?.Invoke(_health);
        }
    }

    protected abstract void Death();
}
