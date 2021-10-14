using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _target;

    private void Update()
    {
        Vector2 direction = _target.transform.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime);
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }
}
