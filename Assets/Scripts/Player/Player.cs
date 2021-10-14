using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int Health { get; private set; }
    public int MaxHealth { get; } = 10;
    public int Money { get; private set; } = 0;

    public event UnityAction Died;
    public event UnityAction<int> MoneyReceived;
    public event UnityAction MoneyChanged;
    public event UnityAction HealthChanged;

    private void Awake()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        HealthChanged?.Invoke();

        if (Health <= 0)
            Die();
    }

    public void PlusReward(Enemy enemy)
    {
        Money += enemy.Reward;

        MoneyReceived?.Invoke(enemy.Reward);
        MoneyChanged?.Invoke();
    }

    public void MinusMoney(int price)
    {
        Money -= price;

        MoneyChanged?.Invoke();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
