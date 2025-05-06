using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private EnemyMover _enemyMover;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
        if(_playerMover != null)
            _playerMover.DirectionChanged += OnDirectionChanged;
        if (_enemyMover != null)
            _enemyMover.DirectionChanged += OnDirectionChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
        _playerMover.DirectionChanged -= OnDirectionChanged;
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

    protected abstract void UpdateHealthDisplay(float currentHealth);

    protected void OnHealthChanged(float currentHealth)
    {
        UpdateHealthDisplay(_health.CurrentHealth);
    }
}
