using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class MoneyText : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;

    private TMP_Text _textMoney;

    private void Start()
    {
        _textMoney = GetComponent<TMP_Text>();
        SetCurrentMoney();
    }

    private void OnEnable()
    {
        _playerMoney.MoneyChanged += SetCurrentMoney;
    }

    private void OnDisable()
    {
        _playerMoney.MoneyChanged -= SetCurrentMoney;
    }

    private void SetCurrentMoney()
    {
        _textMoney.text = _playerMoney.Count.ToString();
    }
}
