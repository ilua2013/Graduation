using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetDetermine : MonoBehaviour
{
    private CircleCollider2D _collider;
    private List<Enemy> _enemies;
    private Enemy _target;

    public event UnityAction<Enemy> TargetFound;

    private void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        _enemies = new List<Enemy>();
    }

    private void Update()
    {
        if (_enemies.Count > 0)
            FindTarget();

        if (_enemies.Count == 0 && _target != null)
            TargetFound?.Invoke(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemies.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemies.Remove(enemy);
    }

    private void FindTarget()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            Enemy enemy = _enemies[i];
            Vector2 magnitude = gameObject.transform.position - enemy.transform.position;
            Vector2 currentMagnitude = gameObject.transform.position - enemy.transform.position;

            if(magnitude.magnitude < currentMagnitude.magnitude || _target == null)
                _target = _enemies[i];
        }

        TargetFound?.Invoke(_target);
    }
}
