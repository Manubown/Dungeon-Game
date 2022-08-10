using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMeeleAttack : MonoBehaviour
{
    public int damage = 20;
    public float cooldDown = 3f;

    private GameObject player;
    private int playerCount = 0;
    private float timeSpent = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeSpent = cooldDown;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerCount < 2)
        {
            playerCount++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerCount >= 2 && timeSpent >= cooldDown)
        {
            timeSpent = 0;
            player.GetComponent<PlayerHealthsystem>().Attacked(damage);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerCount > 0) playerCount--;
    }
}
