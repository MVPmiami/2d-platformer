using UnityEngine;

public class PlayerHealthController : HealthController
{
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] Player _player;

    private void OnEnable()
    {
        _playerCollector.HealthPotionSelected += RestoreHealth;
        _player.TookDamage += ReduceHealth;
    }

    private void OnDisable()
    {
        _playerCollector.HealthPotionSelected -= RestoreHealth;
        _player.TookDamage -= ReduceHealth;
    }

    protected override void Death()
    {
        Destroy(_player.gameObject);
    }
}
