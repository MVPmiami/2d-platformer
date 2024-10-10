using UnityEngine;

public class HealthPotion : MonoBehaviour, IPickable
{
    [SerializeField] private float _healthRecovery;

    public float GetHealthRocoveryValue() => _healthRecovery;

    public void PickUp() => Destroy(gameObject);
}
