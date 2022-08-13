using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public int heal = 50;

    private bool lootAble = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (lootAble && Input.GetKeyDown(KeyCode.F))
        {
            player.GetComponent<PlayerHealthsystem>().Heal(heal);
            Destroy(gameObject);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            lootAble = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            lootAble = false;
        }
    }

}
