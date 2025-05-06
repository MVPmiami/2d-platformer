using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private PlayerHealth _playerHealth;

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
                _playerMover.Attack(enemy);
                _playerAnimator.Attack();
            }
        }
    }
}
