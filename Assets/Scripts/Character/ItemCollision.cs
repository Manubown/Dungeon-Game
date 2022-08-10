
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;

    public class ItemCollision : MonoBehaviour
    {
        public KeyCode ItemPickUpKey = KeyCode.F;
        public List<GameObject> itemsInRange;
        
        private void Update()
        {
            if (Input.GetKeyDown(ItemPickUpKey))
            {
                Debug.Log("PICK UP CLICK");
                foreach (var item in itemsInRange)
                {
                    item.GetComponent<ItemObject>().HandlePickUpItem();
                    Debug.Log("Picked UP");
                }
            }
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Item")
            {
                Debug.Log("Item in Range");
                itemsInRange.Add(collision.gameObject);
            }

        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Item")
            {
                Debug.Log("Item out of Range");
                itemsInRange.Remove(collision.gameObject);
            }
            
        }
    }
