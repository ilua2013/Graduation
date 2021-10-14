using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private float _timeToDestroy = 2;
    private float _elapssedTime;

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        _elapssedTime += Time.deltaTime;
        if (_elapssedTime >= _timeToDestroy)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            enemy.TakeDamage(_damage);

        Destroy(gameObject);
    }
}
