using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            var direction = transform.position - player.transform.position;

            player.gameObject.transform.position += direction.normalized * 0.5f;
        }

        if (collision.gameObject.TryGetComponent<Asteroid>(out Asteroid asteroid))
            Destroy(asteroid);
    }
}
