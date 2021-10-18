using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField] private GameObject _windowTowers;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private float _offsetY;

    private PathBuild _pathBuild;

    public void OpenWindowTowers(PathBuild pathBuild)
    {
        _pathBuild = pathBuild;
        _windowTowers.transform.position = new Vector3(pathBuild.transform.position.x, pathBuild.transform.position.y + _offsetY);

        _windowTowers.SetActive(true);
    }

    public void BuildTower(int indexTower)
    {
        if(_playerMoney.Count > _towers[indexTower].Price)
        {
            Instantiate(_towers[indexTower], _pathBuild.transform.position, Quaternion.identity);
            Destroy(_pathBuild);

            _playerMoney.MinusMoney(_towers[indexTower].Price);
        }

        _windowTowers.SetActive(false);
    }
}
