using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWave : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;


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
        GameObject b = Instantiate(bullet, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0));
        b.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed/* * Time.deltaTime*/;
        b.GetComponent<SpriteRenderer>().color = ballColor;
        Destroy(b, 5);

        GameObject down = Instantiate(bullet, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0));
        down.GetComponent<Rigidbody2D>().velocity = transform.up*-1 * bulletSpeed/* * Time.deltaTime*/;
        down.GetComponent<SpriteRenderer>().color = ballColor;
        Destroy(down, 5);

        GameObject right = Instantiate(bullet, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0));
        right.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed/* * Time.deltaTime*/;
        right.GetComponent<SpriteRenderer>().color = ballColor;
        Destroy(right, 5);

        GameObject left = Instantiate(bullet, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0));
        left.GetComponent<Rigidbody2D>().velocity = transform.right*-1 * bulletSpeed/* * Time.deltaTime*/;
        left.GetComponent<SpriteRenderer>().color = ballColor;
        Destroy(left, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") inRange = false;
    }

}
