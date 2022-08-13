using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewArmorItem", menuName = "Inventory System/Items/Default")]
public class Default : Item
{
    public void Awake()
    {
        type = ItemType.Item;
    }
}
