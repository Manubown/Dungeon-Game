using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 1;
    public float cooldown = 2.5f;
    public Color ballColor = Color.white;
    public bool triggerAttack = false;

    private bool inRange = false;
    private bool onCooldown = false;
    private float timeSpent = 0;

    private GameObject player;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        
        // Gets a vector that points from the player's position to the target's.
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;
        direction = heading / distance; // This is now the normalized direction.

        if (!triggerAttack)
        {
            if (inRange && !onCooldown)
            {
                onCooldown = true;
                timeSpent = 0;
                Shoot();
            }
            else
            {
                timeSpent += Time.deltaTime;
                if (timeSpent >= cooldown)
                {
                    onCooldown = false;
                    timeSpent = 0;
                }
            }
        }
    }

    public void Shoot()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Gets a vector that points from the player's position to the target's.
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;
        direction = heading / distance; // This is now the normalized direction.
        GameObject b = Instantiate(bullet,transform.position,new Quaternion(transform.rotation.x,transform.rotation.y-180,transform.rotation.z,0));
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed/* * Time.deltaTime*/;
        b.GetComponent<SpriteRenderer>().color = ballColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player") inRange = false;
    }
}
