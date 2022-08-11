using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

    public class ItemObject:MonoBehaviour
    {
        public Item refData;

        public void HandlePickUpItem()
        {
            Debug.Log("Picked up: " + refData.Name);
            InventorySystem.current.Add(refData);
            Destroy(gameObject);
        }
    }
