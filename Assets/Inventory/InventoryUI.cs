using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySystem inventory;

    private Dictionary<InventoryItem, GameObject> displayedItems = new Dictionary<InventoryItem, GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        CreateInventory();
    }

    public void CreateInventory()
    {
        for (int i = 0; i < inventory.PlayerInventory.Count; i++)
        {
            var obj = Instantiate(inventory.PlayerInventory[i].data.prefab, Vector3.zero,Quaternion.identity, transform);
            var texts = obj.GetComponentsInChildren<Text>();
            texts[0].text = inventory.PlayerInventory[i].data.Name;
            texts[1].text = inventory.PlayerInventory[i].stackSize.ToString();
            obj.GetComponentInChildren<Image>().sprite = inventory.PlayerInventory[i].data.icon;
            displayedItems.Add(inventory.PlayerInventory[i], obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
