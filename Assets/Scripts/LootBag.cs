using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    private bool lootAble = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lootAble && Input.GetKeyDown(KeyCode.F)) Destroy(gameObject);
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
