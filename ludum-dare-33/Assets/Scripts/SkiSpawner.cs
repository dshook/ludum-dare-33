using UnityEngine;
using Util;

public class SkiSpawner : MonoBehaviour
{
    RectTransform spawnArea;
    public GameObject skiierPrefab;
    public GameObject noobPrefab;
    public GameObject boarderPrefab;

    public float spawnTime = 3f;
    float timer = 0f;
    float maxPlayerDistance = 20f;
    GameObject player;

    void Start()
    {
        spawnArea = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        var bounds = Camera.main.OrthographicBounds();
        var areaBounds =  new Bounds(transform.position, new Vector3(spawnArea.rect.width, spawnArea.rect.height, 0.0f));
        
        var intersected = bounds.Intersects(areaBounds);
        var closeEnough = Vector2.Distance(spawnArea.position, player.transform.position) < maxPlayerDistance;
        //only spawn if we can't see any of the spawn area but yet the area is close enough
        if (!intersected && closeEnough )
        {
            if (timer > spawnTime)
            {
                Spawn();
                timer = 0;
            }
        }
    }

    void Spawn()
    {
        Vector2 spawnpoint = new Vector2(
            Random.Range(spawnArea.position.x + spawnArea.rect.xMin, spawnArea.position.x + spawnArea.rect.xMax),
            Random.Range(spawnArea.position.y + spawnArea.rect.yMin, spawnArea.position.y + spawnArea.rect.yMax )
        );

        GameObject prefab;
        var prefabChance = Random.Range(0f, 1f);
        if (prefabChance < 0.5f)
        {
            prefab = skiierPrefab;
        }
        else if (prefabChance < 0.8f)
        {
            prefab = boarderPrefab;
        }
        else
        {
            prefab = noobPrefab;
        }

        Instantiate(prefab, spawnpoint, Quaternion.identity);
    }
}
