using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionWithPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Wall")
        {
            Collider2D[] col = collision.gameObject.GetComponents<Collider2D>();
            Physics2D.IgnoreCollision(col[0], transform.GetComponent<Collider2D>());
        }
    }
}
