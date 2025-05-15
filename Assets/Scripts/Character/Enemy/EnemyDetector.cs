using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _raycastDistance;

    private Vector2 _direction;
    private Enemy _closestEnemy;

    private void Start()
    {
        _direction = transform.right;
    }

    private void FixedUpdate()
    {
        ChangeDirection();
    }

    public Enemy GetClosestEnemy() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction, _raycastDistance, _enemyLayer);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Enemy enemy))
            _closestEnemy = enemy;
        else
            _closestEnemy = null;

        return _closestEnemy;
    }

    private void ChangeDirection()
    {
        if (transform.localScale.x > 0)
            _direction = Vector2.right;
        else
            _direction = -Vector2.right;
    }
}
