using UnityEngine;

public class HealthController : MonoBehaviour
{
    //������� ����� ����������� ����� HealthController, � ���� ����� PlayerHealthController
    //���������� PlayerCollector, EnemyMover
    //����������� �� 2 ������� �� ������ �� � �� ����� �� ������������
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
        //������ ����� ���� ����� ������������ ����������
        Destroy(_player.gameObject);
    }
}
