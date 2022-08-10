using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    public float cooldownMin = 1.5f;
    public float cooldownMax = 3;

    private float cooldown;

    private AttackOnPlayerPosition attackOnPlayerPosition;
    private Attack attack;
    private AttackWave attackWave;
    private SpawnInArea spawnInArea;

    private Queue<dynamic> attackRotation;

    private float time = 0;
    private bool onCooldown = false;
    private bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        attack = gameObject.GetComponent<Attack>();
        attackOnPlayerPosition = gameObject.GetComponent<AttackOnPlayerPosition>();
        attackWave = gameObject.GetComponent<AttackWave>();
        spawnInArea = gameObject.GetComponent<SpawnInArea>();
        attackRotation = new Queue<dynamic>();

        attackRotation.Enqueue(attack);
        attackRotation.Enqueue(attackOnPlayerPosition);
        attackRotation.Enqueue(attackWave);
        attackRotation.Enqueue(spawnInArea);

        cooldown = Random.Range(cooldownMin,cooldownMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (!onCooldown && inRange)
        {
            onCooldown = true;
            cooldown = Random.Range(cooldownMin, cooldownMax);
            Attack();
        }
        else
        {
            time += Time.deltaTime;
            if (time >= cooldown)
            {
                onCooldown = false;
                time = 0;
            }

        }
    }

    void Attack()
    {
        var att = attackRotation.Dequeue();
        if(att is Attack)
        {
            attack.Shoot();
            attackRotation.Enqueue(attack);
        }
        else if(att is AttackOnPlayerPosition)
        {
            attackOnPlayerPosition.Attack();
            attackRotation.Enqueue(attackOnPlayerPosition);
        }
        else if(att is AttackWave)
        {
            attackWave.Shoot();
            attackRotation.Enqueue(attackWave);
        }
        else
        {
            spawnInArea.Spawn(transform.position);
            attackRotation.Enqueue(spawnInArea);
        }
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
