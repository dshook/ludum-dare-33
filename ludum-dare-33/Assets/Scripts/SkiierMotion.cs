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
    GameObject player;
    float maxDistance = 20f;

    bool crashed = false;
    float crashedTimer = 0f;
    Vector2 crashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

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

        if (crashed)
        {
            crashedTimer += Time.fixedDeltaTime;

            if (crashedTimer > 2.5f)
            {
                anim.SetTrigger("GetUp");
                crashed = false;
                //push off
                int crashDirectionSign = (int)crashDirection.normalized.x;
                rb.AddForce(new Vector2(5 * -crashDirectionSign, 0));
            }
            return;
        }

        if (turnTimer > turnEvery)
        {
            Turn();
            turnTimer = 0;
        }

        anim.SetInteger("Direction", (int)direction);
        rb.AddForce(forceDictionary[direction]);

        //destroy the skiier if they are lower down the mountain than the player and far enough away
        if (transform.position.y < player.transform.position.y
            && Vector2.Distance(transform.position, player.transform.position) > maxDistance
        )
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Crash");
            crashed = true;
            crashedTimer = 0f;
            crashDirection = rb.velocity;
            rb.velocity = Vector2.zero;
        }
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
