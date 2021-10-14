using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDie : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        gameObject.SetActive(false);
        _player.Died += OpenPanel;
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        _player.Died -= OpenPanel;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }
}
