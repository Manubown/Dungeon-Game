using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWeaponItem", menuName = "Inventory System/Items/Weapon")]
public class Weapon : Item
{
    public int Strenght;
    public int Health;
    public int Level;
    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
