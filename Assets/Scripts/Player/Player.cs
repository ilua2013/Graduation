using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMoney))]
public class Player : MonoBehaviour
{
    public int Health { get; private set; }
    public int MaxHealth { get; } = 10;

    public event UnityAction Died;
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

    private void Die()
    {
        Died?.Invoke();
    }
}
