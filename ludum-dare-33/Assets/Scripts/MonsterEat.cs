using UnityEngine;
using System.Collections;

public class MonsterEat : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            anim.SetTrigger("Eating");
            Destroy(other.gameObject);
        }
    }

    void Update()
    {

    }
}
