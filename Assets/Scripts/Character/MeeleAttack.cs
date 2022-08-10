using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeeleAttack : MonoBehaviour
{
    public int damage;
    public float cooldown = 1f;

    private Movement movement;

    private List<GameObject> enemiesInRange;
    private List<GameObject> skullsInRange;

    private bool attacks = false;
    private float timeSinceAttack = 0;

    //Animation Trigger
        //Attack
    private static readonly int attackDown = Animator.StringToHash("AttackDown");
    private static readonly int attackUp = Animator.StringToHash("AttackUp");
    private static readonly int attackLeft = Animator.StringToHash("AttackLeft");
    private static readonly int attackRight = Animator.StringToHash("AttackRight");

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        enemiesInRange = new List<GameObject>();
        skullsInRange = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attacks && timeSinceAttack >= cooldown)
        {
            attacks = false;
            timeSinceAttack = 0;
        }
        else
        {
            timeSinceAttack += Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && attacks == false)
        {
            Invoke("Attack", 0.15f);
            attacks = true;
            timeSinceAttack = 0;
            switch (movement.direction)
            {
                case Direction.up:
                    movement.animator.SetTrigger(attackUp);
                    break;
                case Direction.down:
                    movement.animator.SetTrigger(attackDown);
                    break;
                case Direction.right:
                    movement.animator.SetTrigger(attackRight);
                    break;
                case Direction.left:
                    movement.animator.SetTrigger(attackLeft);
                    break;
            }
            //enemiesInRange.ForEach(x => x.GetComponent<Healthsystem>().Attacked(damage));
        }
        enemiesInRange.RemoveAll(x => x == null);
        skullsInRange.RemoveAll(x => x == null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemie" && !enemiesInRange.Contains(collision.gameObject)) enemiesInRange.Add(collision.gameObject);
        if(collision.tag == "Skull" && !skullsInRange.Contains(collision.gameObject)) skullsInRange.Add(collision.gameObject);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemie") enemiesInRange.Remove(collision.gameObject);
        if(collision.tag == "Skull") skullsInRange.Remove(collision.gameObject);
    }

    private void Attack()
    {
        enemiesInRange.Where(x => x != null).ToList().ForEach(x => x.GetComponent<Healthsystem>().Attacked(damage));
        skullsInRange.Where(x => x != null).ToList().ForEach(x => x.GetComponent<DestroySkull>().Destroyed());
    }
}
