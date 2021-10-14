using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForWave : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _count;

    public Enemy Enemy => _enemy;
    public int Count => _count;

    public void MinusCount()
    {
        _count--;
        
        if (_count < 1)
            Destroy(this);
    }
}
