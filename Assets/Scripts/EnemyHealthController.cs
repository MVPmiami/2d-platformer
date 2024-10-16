using UnityEngine;

public class EnemyHealthController : HealthController
{
    [SerializeField] Enemy _enemy;

    private void OnEnable()
    {
        _enemy.TookDamage += ReduceHealth;
    }

    private void OnDisable()
    {
        _enemy.TookDamage -= ReduceHealth;
    }

    protected override void Death()
    {
        Destroy(_enemy.gameObject);
    }
}
