using UnityEngine;
using System.Collections;

public class MonsterEat : MonoBehaviour
{
    Animator anim;
    public ScoreManager score;
    public AudioClip eatClip;

    public int currentFood;
    public int maxFood = 100;
    public int peopleFood = 5;

    public bool eating = false;

    public float hungryEvery = 1f;
    public float eatTime = 0.8f;
    float hungerTimer = 0f;
    AudioSource audioSource;

    public bool dead
    {
        get
        {
            return currentFood <= 0;
        }
    }

    void Start()
    {
        currentFood = maxFood;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (dead) return;

        if (other.gameObject.CompareTag("Food"))
        {
            anim.SetTrigger("Eating");
            score.Eat();
            currentFood = Mathf.Min(maxFood, currentFood + peopleFood);
            Destroy(other.gameObject);

            eating = true;
            if (audioSource != null)
            {
                audioSource.PlayOneShot(eatClip);
            }
            StartCoroutine(DoneEating());
        }
    }

    IEnumerator DoneEating()
    {
        yield return new WaitForSeconds(eatTime);

        eating = false;
        yield return null;
    }

    void Update()
    {
        if (dead) return;

        hungerTimer += Time.deltaTime;
        if (hungerTimer > hungryEvery)
        {
            hungerTimer = 0f;
            currentFood -= 1;

            if (dead)
            {
                anim.SetTrigger("Dead");
            }
        }
    }
}
