using System;
using UnityEngine;


public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _raycastDistance;

    public event Action<bool,float> PlayerDetected;

    private Vector2 _direction;

    private void Start()
    {
        _direction = transform.right;
    }

    private void FixedUpdate()
    {
        ChangeDirection();
        Debug.DrawRay(transform.position, _direction * _raycastDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction, _raycastDistance, _playerLayer);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Player player))
            PlayerDetected?.Invoke(true,hit.distance);
        else
            PlayerDetected?.Invoke(false, hit.distance);
    }

    private void ChangeDirection()
    {
        if (transform.localScale.x > 0)
            _direction = Vector2.right;
        else
            _direction = -Vector2.right;
    }
}
