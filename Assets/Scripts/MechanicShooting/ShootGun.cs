using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _pointShooting;
    [SerializeField] private float _delay;
    [SerializeField] private TargetDetermine _targetDetermine;

    private Animator _animator;
    private Enemy _target;
    private float _elapssedTime;

    private void Start()
    {
        _elapssedTime = _delay;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_target == null)
        {
            _elapssedTime = _delay;
            return;
        }

        _elapssedTime += Time.deltaTime;

        if(_elapssedTime >= _delay)
        {
            _animator.SetTrigger("Shoot");
            Instantiate(_bullet, _pointShooting.position, gameObject.transform.rotation);

            _elapssedTime = 0;
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
