using UnityEngine;
using Assets.Scripts;
using Util;

public class MonsterMove : MonoBehaviour
{
    public float speed = 5f;
    public Transform minYPosition;

    Direction lastDirection = Direction.S;
    Direction direction = Direction.S;

    Rigidbody2D rb;
    Animator anim;
    Vector2 moveDirection;
    MonsterEat eat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        eat = GetComponent<MonsterEat>();
    }

    void FixedUpdate()
    {
        moveDirection.Set(0, 0);

        if (eat.dead || eat.eating) return;

        if (!FloatUtils.CloseEnough(Input.GetAxis("Horizontal"), 0f))
        {
            moveDirection.Set(Input.GetAxis("Horizontal") * speed, 0);
        }

        if (!FloatUtils.CloseEnough(Input.GetAxis("Vertical"), 0f))
        {
            moveDirection.Set(moveDirection.x, Input.GetAxis("Vertical") * speed);
        }

        if (transform.position.y < minYPosition.position.y)
        {
            moveDirection.Set(moveDirection.x, Mathf.Max(0, moveDirection.y));
        }

        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);

        if (moveDirection.x < 0)
        {
            direction = Direction.W;
        }
        else if (moveDirection.x > 0)
        {
            direction = Direction.E;
        }
        else if (FloatUtils.CloseEnough(moveDirection.x, 0, 0.01f))
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
