using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnPlayerPosition : MonoBehaviour
{
    public GameObject bullet;
    public float cooldown = 2.5f;
    public float secondsToColor = 2;
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
                Attack();
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

    public void Attack()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject b = Instantiate(bullet, player.transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0));
        b.GetComponent<SpriteRenderer>().color = Color.yellow;
        StartCoroutine(ToColor(b));
        Destroy(b, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") inRange = false;
    }

    IEnumerator ToColor(GameObject b)
    {
        yield return new WaitForSeconds(secondsToColor);
        b.GetComponent<SpriteRenderer>().color = ballColor;
    }
}
