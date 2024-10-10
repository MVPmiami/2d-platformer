using System;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private int _fruitCount;

    public event Action<int> FruitCountChanged;
    public event Action<float> HealthPotionSelected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Fruit fruit))
            CollectFruit(fruit);

        if (collision.gameObject.TryGetComponent(out HealthPotion healthPotion))
            CollectHealthPotion(healthPotion);
    }

    private void CollectFruit(IPickable fruit)
    {
        fruit.PickUp();
        _fruitCount++;
        FruitCountChanged?.Invoke(_fruitCount);

    }

    private void CollectHealthPotion(HealthPotion healthPotion)
    {
        healthPotion.PickUp();
        HealthPotionSelected?.Invoke(healthPotion.GetHealthRocoveryValue());
    }
}
