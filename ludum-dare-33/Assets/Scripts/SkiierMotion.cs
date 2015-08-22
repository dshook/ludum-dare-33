using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class SkiierMotion : MonoBehaviour
{
    public float turnEvery = 3f;
    public float speed = 2f;
    Direction direction = Direction.S;
    float turnTimer = 0f;

    Rigidbody2D rb;
    Animator anim;
    Dictionary<Direction, Vector2> forceDictionary;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        forceDictionary = new Dictionary<Direction, Vector2>()
        {
            { Direction.S, new Vector2(0, -speed) },
            { Direction.W, new Vector2(-speed, 0) },
            { Direction.E, new Vector2(speed, 0) }
        };
    }

    void FixedUpdate()
    {
        turnTimer += Time.fixedDeltaTime;

        if (turnTimer > turnEvery)
        {
            Turn();
            turnTimer = 0;
        }

        anim.SetInteger("Direction", (int)direction);
        rb.AddForce(forceDictionary[direction]);
    }

    void Turn()
    {
        var turnRand = Random.Range(0f, 1f);
        if (turnRand > 0.4f)
        {
            turnRand = Random.Range(0f, 1f);
            switch (direction) {
                case Direction.W:
                case Direction.E:
                    direction = Direction.S;
                    break;
                case Direction.S:
                    if (turnRand > 0.5)
                    {
                        direction = Direction.E;
                    }
                    else
                    {
                        direction = Direction.W;
                    }
                    break;
            }
        }
    }
}
