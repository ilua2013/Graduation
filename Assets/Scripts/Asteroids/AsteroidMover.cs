using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidMover : MonoBehaviour
{
    [SerializeField] private Vector3 _translateMax;
    [SerializeField] private Vector3 _translateMin;
    [SerializeField] private float _maxSpeedRotateZ;
    [SerializeField] private float _minSpeedRotateZ;

    private float _directionRotate;
    private Vector3 _direction;

    private void Start()
    {
        _direction = new Vector3(Random.Range(_translateMin.x, _translateMax.x), Random.Range(_translateMin.y, _translateMax.y));

        _directionRotate = Random.Range(_minSpeedRotateZ, _maxSpeedRotateZ);
    }

    private void Update()
    {
        transform.Translate(_direction * Time.deltaTime, Space.World);

        transform.Rotate(new Vector3(0, 0, _directionRotate) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newDirection = gameObject.transform.position - collision.transform.position;

        _direction = newDirection.normalized * 3;
    }
}
