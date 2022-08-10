using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventorySystem : MonoBehaviour
{

    public Dictionary<Item, InventoryItem>() itemDirectory;
    public List<InventoryItem> Inventory {get; private set;}

    public KeyCode activationKey = KeyCode.I;
    
    private void Awake()
    {
        Inventory = new List<InventoryItem>();
        itemDirectory = new Dictionary<Item, InventoryItem>();
    }

    
}
