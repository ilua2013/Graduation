using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGun : MonoBehaviour
{
    [SerializeField] private TargetDetermine _targetDetermine;

    private Enemy _target;

    private void Update()
    {
        if (_target != null)
        {
            Vector2 direction = _target.transform.position - gameObject.transform.position;
            gameObject.transform.up = direction.normalized;
        }
    }

    private void OnEnable()
    {
        _targetDetermine.TargetFound += SetTarget;
    }

    private void OnDisable()
    {
        _targetDetermine.TargetFound -= SetTarget;
    }

    private void SetTarget(Enemy enemy)
    {
        _target = enemy;
    }
}
