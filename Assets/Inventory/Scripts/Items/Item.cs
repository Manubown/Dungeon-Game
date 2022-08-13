using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Armor,
    Weapon,
    Item,
}


public abstract class Item : ScriptableObject
{
    public GameObject prefab;
    public string id;
    public Sprite icon;
    public string Name;
    public ItemType type;
    
    [TextArea(15,20)]
    public string description;

}
