using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") collision.gameObject.GetComponent<PlayerHealthsystem>().Attacked(damage);
        Destroy(gameObject);
    }
}
