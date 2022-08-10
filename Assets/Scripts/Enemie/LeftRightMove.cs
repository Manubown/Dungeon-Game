using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    public bool facingLeft = true;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update()
	{
        if (player == null) return;

        if (facingLeft)
        {
            if (player.transform.position.x > transform.position.x) transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, 0);
            else transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0);
        }
        else
        {
            if (player.transform.position.x > transform.position.x) transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0);
            else transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, 0);
        }
    }

}
