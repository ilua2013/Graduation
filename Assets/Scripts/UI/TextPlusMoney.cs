using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPlusMoney : MonoBehaviour
{
    private Player _player;
    private TMP_Text _text;
    private Animator _animator;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _text = GetComponent<TMP_Text>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player.MoneyReceived += StartAnimation;
    }

    private void OnDisable()
    {
        _player.MoneyReceived -= StartAnimation;
    }

    public void StartAnimation(int reward)
    {
        _animator.SetTrigger("FinishAnimation");
        _animator.SetTrigger("PlusMoney");
        _text.text = $"+{reward}";
    }
}
