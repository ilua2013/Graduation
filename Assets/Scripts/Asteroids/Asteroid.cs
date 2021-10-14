using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private ParticleSystem _destroyVfx;

    private void Start()
    {
        _destroyVfx = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
            StartCoroutine(StartVfx());
    }

    private IEnumerator StartVfx()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        gameObject.GetComponent<Collider2D>().isTrigger = true;

        var wait = new WaitForSeconds(_destroyVfx.duration);

        _destroyVfx.Play();

        yield return wait;
        Destroy(gameObject);
    }
}
