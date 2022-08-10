using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damage = 20;
    public float cooldDown = 3f;

    private Animator animator;
    private static readonly int trap = Animator.StringToHash("Trap");
    private static readonly int trapEnd = Animator.StringToHash("TrapEnd");

    private GameObject player;
    private int playerCount = 0;
    private float timeSpent = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        timeSpent = cooldDown;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        if(player == null)
        {
            animator.SetBool(trapEnd, true);
            animator.SetBool(trap, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerCount++;
        }

        if(playerCount >= 2)
        {
            animator.SetBool(trap, true);
            animator.SetBool(trapEnd, false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerCount--;
            animator.SetBool(trapEnd, true);
            animator.SetBool(trap,false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerCount >= 2 && timeSpent >= cooldDown)
        {
            timeSpent = 0;
            player.GetComponent<PlayerHealthsystem>().Attacked(damage);
        }
    }

}
