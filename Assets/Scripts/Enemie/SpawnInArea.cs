using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInArea : MonoBehaviour
{
    public float radius = 1;
    public GameObject prefab;

    public void Spawn(Vector2 pos)
    {
        var r = pos + Random.insideUnitCircle * radius;
        Instantiate(prefab, r, transform.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
