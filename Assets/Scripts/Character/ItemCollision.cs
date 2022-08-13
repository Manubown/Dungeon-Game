
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    using UnityEngine.Serialization;

    public class ItemCollision : MonoBehaviour
    {
        [FormerlySerializedAs("itemsInRange")] public KeyCode ItemPickUpKey = KeyCode.F;
        public GameObject itemInRange;
        
        
        private void Update()
        {
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
