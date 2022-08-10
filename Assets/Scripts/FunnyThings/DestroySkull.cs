using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySkull : MonoBehaviour
{
    public bool isGlas = false;
    public GameObject skullFragment;
    public bool drop = true;
    public int dropRateOneOf = 10;

    private static readonly int breakGlas = Animator.StringToHash("Break");
    private bool glasBroken = false;
    public void Destroyed()
    {
        if (isGlas)
        {
            if (glasBroken) return;
            transform.GetComponent<Animator>().SetTrigger(breakGlas);
            glasBroken = true;
            if (Random.Range(0, dropRateOneOf) == 0 && drop) gameObject.GetComponent<MonsterLoot>().DropLoot();
        }
        else
        {
            Instantiate(skullFragment, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            if (Random.Range(0, dropRateOneOf) == 0 && drop) gameObject.GetComponent<MonsterLoot>().DropLoot();
            Destroy(gameObject);
        }
    }
}
