using UnityEngine;
using UnityEngine.UI;

public class GUIHunger : MonoBehaviour
{
    public Text text;
    MonsterEat eat;

    void Start()
    {
        eat = GameObject.FindGameObjectWithTag("Player").GetComponent<MonsterEat>();
    }

    void Update()
    {
        text.text = string.Format("Food: {0} / {1}", eat.currentFood, eat.maxFood);
        if (((float)eat.currentFood / (float)eat.maxFood) < 0.1f)
        {
            text.color = Color.red;
        }
        else
        {
            text.color = Color.black;
        }
    }
}
