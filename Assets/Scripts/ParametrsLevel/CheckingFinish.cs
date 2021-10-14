using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingFinish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;

    private List<Enemy> _enemys;

    private void OnEnable()
    {
        var enemys = FindObjectsOfType<Enemy>();

        _enemys = new List<Enemy>();
        for (int i = 0; i < enemys.Length; i++)
        {
            _enemys.Add(enemys[i]);
            _enemys[i].EnemyDied += DeleteNull;
        }
    }

    private void DeleteNull(Enemy enemy)
    {
        enemy.EnemyDied -= DeleteNull;
        _enemys.Remove(enemy);

        if (_enemys.Count == 0)
            Finish();
    }

    private void Finish()
    {
        _finishPanel.SetActive(true);
    }
}
