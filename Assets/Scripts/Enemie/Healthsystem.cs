using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour
{
    public int health = 100;

    public bool dead = false;
    public HealthBar healthBar;

    private void Start()
    {
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(health);
        }
    }

    public void Attacked(int damage)
    {
        health -= damage;
        if(healthBar != null)
        {
            healthBar.SetHealth(health);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("BackToWhite", 0.25f);
        if (health <= 0)
        {
            if(gameObject.GetComponent<MonsterLoot>() != null) gameObject.GetComponent<MonsterLoot>().DropLoot();
            if(gameObject.transform.parent != null) Destroy(gameObject.transform.parent.gameObject, 0.25f);
            Destroy(gameObject, 0.25f);
            if (healthBar != null)
            {
                if (gameObject.GetComponent<BossHealthbar>() == null)
                {
                    transform.parent.GetComponent<BossHealthbar>().healthbar.SetActive(false);
                }
                else
                {
                    gameObject.GetComponent<BossHealthbar>().healthbar.SetActive(false);
                }
                dead = true;
            }
        }
    }

    private void BackToWhite()
    {
        if(gameObject != null) gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
