using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBuild : MonoBehaviour
{
    private Construction _construction;
    private bool _playerInCollider = false;

    private void Awake()
    {
        _construction = GetComponentInParent<Construction>();
    }

    private void Update()
    {
        if (_playerInCollider && Input.GetKeyDown(KeyCode.Space))
            _construction.OpenWindowTowers(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _playerInCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _playerInCollider = false;
    }
}
