using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private Player _player;

    public event UnityAction<Enemy> EnemyDied;

    public int Reward => _reward;

    private void OnDisable()
    {
        EnemyDied -= _player.GetComponent<PlayerMoney>().PlusReward;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public void SetTarget(Player player)
    {
        _player = player;
        EnemyDied += _player.GetComponent<PlayerMoney>().PlusReward;
    }

    private void Die()
    {
        EnemyDied?.Invoke(this);
        Destroy(gameObject);
    }
}
