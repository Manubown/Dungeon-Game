using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventorySystem : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public GameObject itemInRange;
    
    

    public KeyCode activationKey = KeyCode.I;
    public bool isActive = false;
    public GameObject inv;
    
    private void OnApplicationQuit()
    {
        inventorySystem.PlayerInventory.Clear();
        inventorySystem.PlayerItemDirectory.Clear();
    }

    private void Start()
    {
        inv.SetActive(isActive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&& itemInRange!=null)
        {
            var item = itemInRange.GetComponent<ItemObject>();
            if (item)
            {
                inventorySystem.AddItem(item.refData);
                Destroy(itemInRange.gameObject);
            }
        }

        if (Input.GetKeyDown(activationKey))
        {
            isActive = !isActive;
            inv.SetActive(isActive);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            itemInRange = (collision.gameObject);
        }
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            itemInRange = null;
        }
    }
}
