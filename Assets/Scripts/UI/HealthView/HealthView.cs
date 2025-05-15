using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Mover _mover;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;

        if(_mover != null)
            _mover.DirectionChanged += OnDirectionChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
        _mover.DirectionChanged -= OnDirectionChanged;
    }

    private void OnDirectionChanged(float horizontInput)
    {
        if (horizontInput * transform.localScale.x < 0)
            Flip();
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnHealthChanged(float currentHealth)
    {
        UpdateHealthDisplay(_health.CurrentHealth);
    }

    protected abstract void UpdateHealthDisplay(float currentHealth);
}
