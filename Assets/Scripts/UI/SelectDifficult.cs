using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficult : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private GameObject _textWaveFinish;
    [SerializeField] private CheckingFinish _checkingFinish;
    [SerializeField] private WavesController _easyLevel;
    [SerializeField] private WavesController _mediuumLevel;
    [SerializeField] private WavesController _hardLevel;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void SelectEasyLevel()
    {
        SelectLevel(_easyLevel);
    }

    public void SelectMediumLevel()
    {
        SelectLevel(_mediuumLevel);
    }

    public void SelectHardLevel()
    {
        SelectLevel(_hardLevel);
    }

    private void SelectLevel(WavesController level)
    {
        WavesController wavesController = Instantiate(level, Vector3.zero, Quaternion.identity);

        wavesController.Initialize(_spawners, _textWaveFinish, _checkingFinish);

        gameObject.SetActive(false);
    }
}
