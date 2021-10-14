using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid[] _asteroids;
    [SerializeField] private float _delaySpawn;

    private Spawner _spawner;
    private float _elapssedTime;

    private void Start()
    {
        _spawner = GetComponentInChildren<Spawner>();
    }

    private void Update()
    {
        _elapssedTime += Time.deltaTime;

        if (_elapssedTime >= _delaySpawn)
        {
            _spawner.InstatiateAsteroid(_asteroids[Random.Range(0,_asteroids.Length)]);
            _elapssedTime = 0;
        }
    }
}
