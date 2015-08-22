using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class MonsterMove : MonoBehaviour
{
    public float speed = 5f;
    Direction lastDirection = Direction.S;
    Direction direction = Direction.S;

    Rigidbody2D rb;
    Animator anim;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if (Input.GetAxis("Horizontal") != 0f)
        {
            moveDirection.Set(Input.GetAxis("Horizontal") * speed, 0);
        }

        if (Input.GetAxis("Vertical") != 0f)
        {
            moveDirection.Set(moveDirection.x, Input.GetAxis("Vertical") * speed);
        }
        rb.AddForce(moveDirection);

        if (moveDirection.x < 0)
        {
            direction = Direction.W;
        }
        else if (moveDirection.x > 0)
        {
            direction = Direction.E;
        }
        else
        {
            direction = Direction.S;
        }

        if (direction != lastDirection)
        {
            lastDirection = direction;
            anim.SetInteger("Direction", (int)direction);
        }
    }
}
