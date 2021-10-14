using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wave : MonoBehaviour
{
    [SerializeField] private bool _upSpawner;
    [SerializeField] private bool _rightSpawner;
    [SerializeField] private bool _downSpawner;
    [SerializeField] private bool _leftSpawner;
    [SerializeField] private float _delay;

    private List<Spawner> _spawners;
    private List<EnemyForWave> _enemys = new List<EnemyForWave>();
    private float _elapssedTime = 0;

    public event UnityAction Finish;

    private void Start()
    {
        var enemys = GetComponentsInChildren<EnemyForWave>();

        for (int i = 0; i < enemys.Length; i++)
            _enemys.Add(enemys[i]);
    }

    public void Initialize(Spawner[] spawners)
    {
        bool[] activeSpawners = { _upSpawner, _rightSpawner, _downSpawner, _leftSpawner };

        _spawners = new List<Spawner>();
        for (int i = 0; i < spawners.Length && i < activeSpawners.Length; i++)
            if (activeSpawners[i])
                _spawners.Add(spawners[i]);
    }

    private void Update()
    {
        _elapssedTime += Time.deltaTime;

        if (_elapssedTime >= _delay)
        {
            _elapssedTime = 0;
            int index = Random.Range(0, _enemys.Count);

            _spawners[Random.Range(0, _spawners.Count)].InstatiateEnemy(_enemys[index].Enemy);
            _enemys[index].MinusCount();

            DeleteNull();
            CheckFinish();
        }
    }

    private void CheckFinish()
    {
        if (_enemys.Count == 0)
            Finish?.Invoke();
    }

    private void DeleteNull()
    {
        for (int i = 0; i < _enemys.Count; i++)
            if (_enemys[i] == null)
                _enemys.RemoveAt(i);
    }
}
