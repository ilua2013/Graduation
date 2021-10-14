using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WavesController : MonoBehaviour
{
    [SerializeField] private float _delayWaves;

    private CheckingFinish _checkingFinish;
    private GameObject _textWaveFinish;
    private Wave[] _waves;
    private int index = 0;
    private float _elapssedTime;

    private void Start()
    {
        _waves[index].Finish += WaveFinish;
        EnableWave(index);

        this.enabled = false;
    }

    private void Update()
    {
        _elapssedTime += Time.deltaTime;

        if (_elapssedTime >= _delayWaves)
            SetNextWave();
    }

    public void Initialize(Spawner[] spawners, GameObject textWaveFinish, CheckingFinish checkingFinish)
    {
        _waves = GetComponentsInChildren<Wave>();

        for (int i = 0; i < _waves.Length; i++)
            _waves[i].Initialize(spawners);

        _textWaveFinish = textWaveFinish;
        _checkingFinish = checkingFinish;
    }

    private void SetNextWave()
    {
        EnableWave(index);
        _waves[index].Finish += WaveFinish;

        this.enabled = false;
    }

    private void WaveFinish()
    {
        _textWaveFinish.SetActive(true);

        _waves[index].enabled = false;
        _waves[index].Finish -= WaveFinish;

        index++;
        if (index < _waves.Length)
            this.enabled = true;
        else
            _checkingFinish.enabled = true;

        _elapssedTime = 0;
    }

    private void EnableWave(int index)
    {
        if(index < _waves.Length)
        {
            for (int i = 0; i < _waves.Length; i++)
                _waves[i].enabled = false;

            _waves[index].enabled = true;
        }
    }
}