using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnPlayer : MonoBehaviour
{
    public int damage = 20;

    private float timeSpent = 0;
    private int playerCount = 0;
    private bool attacked = false;

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player" && timeSpent >= 1f)
    //    {
    //        playerCount++;
    //    }

    //    if(playerCount >= 2)
    //    {
    //        collision.gameObject.GetComponent<PlayerHealthsystem>().Attacked(damage);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && timeSpent >= 1f)
        {
            playerCount++;
        }

        if (playerCount >= 2 && !attacked)
        {
            collision.gameObject.GetComponent<PlayerHealthsystem>().Attacked(damage);
            Destroy(gameObject);
        }
    }
}
