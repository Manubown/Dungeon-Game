using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory System/Inventory")]
public class InventorySystem : ScriptableObject
{
    public Dictionary<Item, InventoryItem> PlayerItemDirectory = new Dictionary<Item, InventoryItem>();
    public List<InventoryItem> PlayerInventory = new List<InventoryItem>();

    
    private void Awake()
    {
        PlayerInventory = new List<InventoryItem>();
        PlayerItemDirectory = new Dictionary<Item, InventoryItem>();
    }

    public void InventoryItem (Item refData)
    {
         AddItem(refData);
    }

    public void AddItem(Item refData)
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

    public void RemoveItem(Item refData)
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
