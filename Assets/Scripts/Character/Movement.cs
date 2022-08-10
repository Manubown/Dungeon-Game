using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Direction
{
    up,
    down,
    right,
    left
}

public class Movement : MonoBehaviour
{

    public int speed = 5;
    public Rigidbody2D rigi;
    public Animator animator;
    public GameObject movementParticles;
    Vector2 movement;
    public Direction direction = Direction.down;

    List<int> AnimationBools = new List<int>();

    //Animation Bools
        //Idle
    private static readonly int idle = Animator.StringToHash("Idle");
    private static readonly int idleDown = Animator.StringToHash("IdleDown");
    private static readonly int idleUp = Animator.StringToHash("IdleUp");
    private static readonly int idleLeft = Animator.StringToHash("IdleLeft");
    private static readonly int idleRight = Animator.StringToHash("IdleRight");
        //Walk
    private static readonly int walk = Animator.StringToHash("Walk");
    private static readonly int walkDown = Animator.StringToHash("WalkDown");
    private static readonly int walkUp = Animator.StringToHash("WalkUp");
    private static readonly int walkLeft = Animator.StringToHash("WalkLeft");
    private static readonly int walkRight = Animator.StringToHash("WalkRight");



    // Start is called before the first frame update
    void Start()
    {
        AnimationBools.Add(idle);
        AnimationBools.Add(idleDown);
        AnimationBools.Add(idleUp);
        AnimationBools.Add(idleLeft);
        AnimationBools.Add(idleRight);
        AnimationBools.Add(walk);
        AnimationBools.Add(walkDown);
        AnimationBools.Add(walkUp);
        AnimationBools.Add(walkLeft);
        AnimationBools.Add(walkRight);
    }

    private void FixedUpdate()
    {
        //Add Movement
        rigi.velocity = new Vector2(movement.x * Time.deltaTime, movement.y * Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Direction
        float inputX = Input.GetAxisRaw("Horizontal");
        if (inputX > 0) direction = Direction.right;
        else if (inputX < 0) direction = Direction.left;
        float inputY = Input.GetAxisRaw("Vertical");
        if (inputY > 0) direction = Direction.up;
        else if (inputY < 0) direction = Direction.down;
        movement = new Vector2(speed * inputX, speed * inputY);
        // Check if Character is moving
        if (rigi.velocity.magnitude > 0)
        {
            movementParticles.SetActive(true);
            if (direction == Direction.left) SetAnimationBool(walkLeft);
            else if (direction == Direction.right) SetAnimationBool(walkRight);
            else if (direction == Direction.down) SetAnimationBool(walkDown);
            else SetAnimationBool(walkUp);
        }
        else
        {
            movementParticles.SetActive(false);
            if (direction == Direction.left) SetAnimationBool(idleLeft);
            else if (direction == Direction.right) SetAnimationBool(idleRight);
            else if (direction == Direction.down) SetAnimationBool(idleDown);
            else SetAnimationBool(idleUp);
        }

    }

    private void SetAnimationBool(int dir)
    {
        animator.SetBool(dir, true);
        AnimationBools.Where(x => dir != x).ToList().ForEach(x => animator.SetBool(x,false));
    }
}
