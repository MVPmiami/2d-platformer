using Unity.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private HealthController _healthController;
    //[SerializeField] private float _maxHealthPoint;
    //[SerializeField] private float _damage;

    //public float Health { get; private set; }

    //private void Start()
    //{
    //    Health = _maxHealthPoint;
    //}

    //private void OnEnable()
    //{
    //    _playerCollector.HealthPotionSelected += RecoverHealth;
    //}

    //private void OnDisable()
    //{
    //    _playerCollector.HealthPotionSelected -= RecoverHealth;
    //}

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _playerAnimator.Run();
            _playerMover.Run(_inputReader.Direction);
        }
        else
        {
            _playerAnimator.Idle();
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _playerMover.Jump();

        if (_inputReader.GetIsAttack())
        {
            Enemy enemy = _enemyDetector.GetClosestEnemy();

            if (enemy != null)
            {
                _playerMover.Attack(_damage, enemy);//урон пусть задается в PlayerMover
                _playerAnimator.Attack();
            }
        }
    }

    //public void TakeDamage(float damage)
    //{
    //    if (Health > damage)
    //        Health -= damage;
    //    else
    //        Death();
    //}

    //private void RecoverHealth(float recoveryValue)
    //{
    //    //ошибка в логике, проверяем не правильно с учетом входдящего исцеления
    //    if (Health < _maxHealthPoint)
    //        Health += recoveryValue;

    //    if (Health > _maxHealthPoint)
    //        Health = _maxHealthPoint;
    //}

    //private void Death()
    //{
    //    Destroy(gameObject);
    //}
}
