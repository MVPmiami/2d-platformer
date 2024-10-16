using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public event Action<float> TookDamage;

    public void TakeDamage(float damage)
    {
        TookDamage?.Invoke(damage);
    }
}
