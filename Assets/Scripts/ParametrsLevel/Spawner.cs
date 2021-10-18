using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _targetEnemy;

    private Vector3 _pathSpawn;
    private float _offsetX;
    private float _offsetY;

    public event UnityAction<Enemy> _enemySpawned;

    private void Start()
    {
        _offsetX = gameObject.transform.localScale.x / 2;
        _offsetY = gameObject.transform.localScale.y / 2;
    }

    public void InstatiateEnemy(Enemy enemy)
    {
        _pathSpawn = new Vector2(Random.Range(_offsetX, -_offsetX), Random.Range(_offsetY, -_offsetY));

        var spawned = Instantiate(enemy, transform.position + _pathSpawn, Quaternion.identity);

        spawned.GetComponent<Enemy>().SetTarget(_targetEnemy);
        spawned.GetComponent<EnemyMover>().SetTarget(_targetEnemy);

        _enemySpawned?.Invoke(spawned);
    }

    public void InstatiateAsteroid(Asteroid asteroid)
    {
        _pathSpawn = new Vector2(Random.Range(_offsetX, -_offsetX), Random.Range(_offsetY, -_offsetY));

        Instantiate(asteroid, transform.position + _pathSpawn, Quaternion.identity);
    }
}
