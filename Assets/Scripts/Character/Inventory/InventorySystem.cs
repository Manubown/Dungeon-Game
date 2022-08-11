using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class InventorySystem : MonoBehaviour
{
    public GameObject InvSlot;
    public GameObject ItemPref;
    public static InventorySystem current;
    public Dictionary<Item, InventoryItem> PlayerItemDirectory;
    public List<InventoryItem> PlayerInventory {get; private set;}

    public List<InventoryItem> Inventory;

    public KeyCode activationKey = KeyCode.I;
    
    private void Awake()
    {
        current = this;
        PlayerInventory = new List<InventoryItem>();
        PlayerItemDirectory = new Dictionary<Item, InventoryItem>();
    }

    private void Update()
    {
        Inventory = PlayerInventory;
    }

    public InventoryItem Get(Item refData)
    {
        if (PlayerItemDirectory.TryGetValue(refData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(Item refData)
    {
        if (PlayerItemDirectory.TryGetValue(refData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(refData);
            PlayerInventory.Add((newItem));
            PlayerItemDirectory.Add(refData, newItem);
        }
        
        Debug.Log("Added: " + refData.Name+" to inventory");
    }

    public void Remove(Item refData)
    {
        if (PlayerItemDirectory.TryGetValue(refData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize <= 0)
            {
                PlayerInventory.Remove((value));
                PlayerItemDirectory.Remove(refData);
            }
        }
    } 
}
