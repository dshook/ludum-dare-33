using UnityEngine;
using System.Collections;

public class LiftSpawner : MonoBehaviour
{

    public Vector2 emptyPosition;
    public Vector2 fullPosition;

    public GameObject emptyPrefab;
    public GameObject fullPrefab;

    public int number;
    public float offset = 5f;

    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            emptyPosition.Set(emptyPosition.x, emptyPosition.y + offset);
            fullPosition.Set(fullPosition.x, fullPosition.y + offset);

            GameObject newEmpty = Instantiate(emptyPrefab, emptyPosition, Quaternion.identity) as GameObject;
            GameObject newFull = Instantiate(fullPrefab, fullPosition, Quaternion.identity) as GameObject;

            newEmpty.transform.parent = gameObject.transform.parent;
            newFull.transform.parent = gameObject.transform.parent;
        }
    }

    void Update()
    {

    }
}
