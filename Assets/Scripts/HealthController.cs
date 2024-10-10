using UnityEngine;

public class HealthController : MonoBehaviour
{
    //создать общий абстрактный класс HealthController, а этот будет PlayerHealthController
    //подключить PlayerCollector, EnemyMover
    //подписаться на 2 события на рестор хп и на редюс хп соответвенно
    [SerializeField] private float _maxHealth;
    [SerializeField] Player _player;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        if (_health <= 0)
            Death();
    }

    public void RestoreHealth(float health)
    {
        if (_health + health > _maxHealth)
            _health = _maxHealth;
        else
            _health += health;
    }

    public void ReduceHealth(float health)
    {
        if (_health - health <= 0)
            Death();
        else
            _health -= health;
    }

    private void Death()
    {
        //скорее всего надо будет пробрасывать геймобчект
        Destroy(_player.gameObject);
    }
}
