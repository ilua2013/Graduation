using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        ChangeValue();
    }

    private void OnEnable()
    {
        _player.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeValue;
    }

    public void ChangeValue()
    {
        _healthBar.value = (float)_player.Health / _player.MaxHealth;
    }
}
