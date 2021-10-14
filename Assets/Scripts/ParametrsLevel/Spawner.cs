using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _targetEnemy;

    private Vector3 pathSpawn;
    private float offsetX;
    private float offsetY;

    public event UnityAction<Enemy> _enemySpawned;

    private void Start()
    {
        offsetX = gameObject.transform.localScale.x / 2;
        offsetY = gameObject.transform.localScale.y / 2;
    }

    public void InstatiateEnemy(Enemy enemy)
    {
        pathSpawn = new Vector2(Random.Range(offsetX, -offsetX), Random.Range(offsetY, -offsetY));

        var spawned = Instantiate(enemy, transform.position + pathSpawn, Quaternion.identity);

        spawned.GetComponent<Enemy>().SetTarget(_targetEnemy);
        spawned.GetComponent<EnemyMover>().SetTarget(_targetEnemy);

        _enemySpawned?.Invoke(spawned);
    }

    public void InstatiateAsteroid(Asteroid asteroid)
    {
        pathSpawn = new Vector2(Random.Range(offsetX, -offsetX), Random.Range(offsetY, -offsetY));

        Instantiate(asteroid, transform.position + pathSpawn, Quaternion.identity);
    }
}
