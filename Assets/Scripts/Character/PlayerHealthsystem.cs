using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthsystem : MonoBehaviour
{
    public int maxhealth = 100;
    public int health = 100;
    public GameObject blood;
    public HealthBar healthBar;

    private bool dead = false;

    private void Start()
    {
        healthBar.SetMaxHealth(maxhealth);
        health = maxhealth;
    }
    public void Attacked(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("BackToWhite", 0.25f);
        if (health <= 0 && !dead)
        {
            dead = true;
            Instantiate(blood, transform.position, transform.rotation);
            Destroy(gameObject, 0.25f);
        }
    }

    public void Heal(int heal)
    {
        if (health + heal <= maxhealth) health += heal;
        else health = maxhealth;
        healthBar.SetHealth(health);
    }

    private void BackToWhite()
    {
        if (gameObject != null) gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
