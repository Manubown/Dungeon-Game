using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewArmorItem", menuName = "Inventory System/Items/Armor")]
public class Armor : Item
{
    public int Resistance;
    public int Defense;
    public int Health;
    public int Level;
    public void Awake()
    {
        type = ItemType.Armor;
    }
}