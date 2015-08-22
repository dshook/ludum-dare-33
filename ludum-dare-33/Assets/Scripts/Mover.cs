using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public Vector2 direction;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition((Vector2)rb.position + direction * Time.fixedDeltaTime);
    }
}
