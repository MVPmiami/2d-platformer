using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputReader _inputReader;

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

    public void Run(float horizontInput)
    {
        _rigidbody.velocity = new Vector2(_speedX * horizontInput, _rigidbody.velocity.y);

        ChangeViewDirection(horizontInput);
    }

    public void Attack(float damage, Enemy enemy)
    {
       enemy.TakeDamage(DealDamage(damage));
    }

    private float DealDamage(float damage)
    {
        return damage;
    }

    private void ChangeViewDirection(float horizontInput)
    {
        if( horizontInput * transform.localScale.x < 0)
            Flip();
    }

    private void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
