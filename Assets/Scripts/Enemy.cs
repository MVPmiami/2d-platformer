using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealthPoint;

    public float Health { get; private set; }

    private void Start()
    {
        Health = _maxHealthPoint;
    }

    public void TakeDamage(float damage)
    {
        if (Health > damage)
            Health -= damage;
        else
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
