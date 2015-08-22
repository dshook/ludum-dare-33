using UnityEngine;
using System.Collections;

public class SkiSpawner : MonoBehaviour
{
    RectTransform spawnArea;
    public GameObject skiierPrefab;

    public float spawnTime = 3f;
    float timer = 0f;

    void Start()
    {

        spawnArea = GetComponent<RectTransform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Vector2 spawnpoint = new Vector2(
            Random.Range(spawnArea.position.x + spawnArea.rect.xMin, spawnArea.position.x + spawnArea.rect.xMax),
            Random.Range(spawnArea.position.y + spawnArea.rect.yMin, spawnArea.position.y + spawnArea.rect.yMax )
        );

        Instantiate(skiierPrefab, spawnpoint, Quaternion.identity);
    }
}
