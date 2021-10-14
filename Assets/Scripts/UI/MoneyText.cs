using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class MoneyText : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _textMoney;

    private void Start()
    {
        _textMoney = GetComponent<TMP_Text>();
        SetCurrentMoney();
    }

    private void OnEnable()
    {
        _player.MoneyChanged += SetCurrentMoney;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= SetCurrentMoney;
    }

    private void SetCurrentMoney()
    {
        _textMoney.text = _player.Money.ToString();
    }
}
