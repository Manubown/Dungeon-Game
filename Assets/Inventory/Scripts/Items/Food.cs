using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFoodItem", menuName = "Inventory System/Items/Food")]
public class Food : Item
{
    public int healtValue;
    public void Awake()
    {
        type = ItemType.Food;
    }
}
