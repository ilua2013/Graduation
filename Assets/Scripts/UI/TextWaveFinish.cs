using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextWaveFinish : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 25), _speed * Time.deltaTime);

        _text.color = Color.Lerp(_text.color, new Color(_text.color.r, _text.color.g, _text.color.b, 0), _speed * Time.deltaTime);

        if (_text.color.a <= 0.1f)
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1);

        transform.position = _startPosition;
    }
}
