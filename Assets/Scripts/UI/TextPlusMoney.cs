using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(Animator))]
public class TextPlusMoney : MonoBehaviour
{
    private PlayerMoney _playerMoney;
    private TMP_Text _text;
    private Animator _animator;
    private const string FinishAnimation = "FinishAnimation";
    private const string PlusMoney = "PlusMoney";

    private void Awake()
    {
        _playerMoney = GetComponentInParent<PlayerMoney>();
        _text = GetComponent<TMP_Text>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerMoney.MoneyReceived += StartAnimation;
    }

    private void OnDisable()
    {
        _playerMoney.MoneyReceived -= StartAnimation;
    }

    public void StartAnimation(int reward)
    {
        _animator.SetTrigger(FinishAnimation);
        _animator.SetTrigger(PlusMoney);
        _text.text = $"+{reward}";
    }
}
