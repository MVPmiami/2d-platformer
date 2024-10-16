using System;
using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;
    [SerializeField] private Transform[] _pathPoints;
    [SerializeField] private int _startPoint;
    [SerializeField] private float _localScale;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private Player _player;
    [SerializeField] private float _improvedSpeed;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private int _currentPoint;
    private bool _isPatrolling;
    private float _distanceToPlayer;
    private bool _isAttacking;
    private Coroutine _coroutine;

    private void Start()
    {
        _isAttacking = false;
        _isPatrolling = true;
        _currentPoint = _startPoint - 1;
    }

    private void FixedUpdate()
    {
        if (_isPatrolling)
        {
            Stop();
            Patrol();
            ChangeViewDirection();
        }
        else
        {
            CheckPit();
            _coroutine ??= StartCoroutine(Attack());
        }

    }

    private void OnEnable()
    {
        _playerDetector.PlayerDetected += SetPatrolStatus;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerDetected -= SetPatrolStatus;
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            _isAttacking = false;
        }
    }

    private void Patrol()
    {
        Transform target = _pathPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        _enemyAnimator.Run();
        _enemyAnimator.StopAttack();

        if (transform.position.x == target.position.x)
            _currentPoint = ++_currentPoint % _pathPoints.Length;
    }

    private void ChangeViewDirection()
    {
        if (_currentPoint != 0)
            transform.localScale = new Vector2(_localScale, _localScale);
        else if (_currentPoint == 0)
            transform.localScale = new Vector2(-_localScale, _localScale);
    }

    private void SetPatrolStatus(bool patrolStatus, float distance)
    {
        _isPatrolling = !patrolStatus;
        _distanceToPlayer = distance;
    }

    private void MoveToPlayer()
    {
        _enemyAnimator.Run();
        Vector2 target = _player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, _improvedSpeed * Time.deltaTime);
    }

    private IEnumerator Attack()
    {
        if (_isAttacking) yield break;

        _isAttacking = true;
        var wait = new WaitForSeconds(1f);

        while (IsPlayerNearby())
        {
            _player.TakeDamage(DealDamage());
            _enemyAnimator.Idle();
            _enemyAnimator.Attack();

            yield return wait;

        }

        _isAttacking = false;
        Stop();
        MoveToPlayer();
    }

    private bool IsPlayerNearby()
    {
        return _distanceToPlayer <= _attackRange;
    }

    private float DealDamage()
    {
        return _damage;
    }

    private void CheckPit()
    {
        Transform target = _pathPoints[_currentPoint];
        float tolerance = 0.1f;

        if (Mathf.Abs(transform.position.x - target.position.x) < tolerance && !_isPatrolling)
        {
            _currentPoint = ++_currentPoint % _pathPoints.Length;
            ChangeViewDirection();
        }
    }
}
