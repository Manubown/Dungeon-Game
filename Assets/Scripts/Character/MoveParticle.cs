using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticle : MonoBehaviour
{
    public GameObject particle;
    public Transform t;
    public Rigidbody2D characterRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = t.position;
        transform.position = new Vector3(pos.x, pos.y, 1f);
        if (characterRB.velocity.magnitude > 0) particle.SetActive(true);
        else particle.SetActive(false);
    }
}
