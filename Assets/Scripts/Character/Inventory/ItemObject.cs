using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

    public class ItemObject:MonoBehaviour
    {
        public Item refData;

        public void HandlePickUpItem()
        {
            InventorySystem.current.Add(refData);
            Destroy(gameObject);
        }
    }
