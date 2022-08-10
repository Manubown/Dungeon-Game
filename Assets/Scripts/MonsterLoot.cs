using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLoot : MonoBehaviour
{
    public GameObject bag;

    public void DropLoot()
    {
        Instantiate(bag, transform.position,transform.rotation);
    }
}
