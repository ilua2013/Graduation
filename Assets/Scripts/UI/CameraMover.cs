using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    private const float _maxDistanceToPlayer = 0.95f;

    private void Start()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }

    private void Update()
    {
        Vector2 distance = _player.transform.position - transform.position;

        _speed = distance.magnitude > 2 ? 7 : 5;

        if (distance.magnitude >= _maxDistanceToPlayer)
            transform.Translate(distance.normalized * _speed * Time.deltaTime);
    }
}
