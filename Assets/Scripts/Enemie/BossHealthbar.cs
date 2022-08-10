using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthbar : MonoBehaviour
{
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            healthbar.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            healthbar.SetActive(false);
        }
    }
}
