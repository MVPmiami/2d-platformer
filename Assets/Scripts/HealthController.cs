using UnityEngine;

public abstract class HealthController : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;

    protected float _health;

    public float MaxHealth => _maxHealth;
    public float Health => _health;

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
    }

    protected virtual void RestoreHealth(float health)
    {
        _health = _health + health > _maxHealth ? _maxHealth : _health += health;
    }

    protected abstract void Death();
}
