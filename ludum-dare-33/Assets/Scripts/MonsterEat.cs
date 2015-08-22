using UnityEngine;
using System.Collections;

public class MonsterEat : MonoBehaviour
{
    Animator anim;
    public ScoreManager score;

    public int currentFood = 100;
    public int maxFood = 100;

    float hungryEvery = 1f;
    float hungerTimer = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            anim.SetTrigger("Eating");
            score.Eat();
            currentFood = Mathf.Min(maxFood, currentFood + 10);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        hungerTimer += Time.deltaTime;
        if (hungerTimer > hungryEvery)
        {
            hungerTimer = 0f;
            currentFood -= 1;
        }
    }
}
