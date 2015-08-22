using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text text;
    int score = 0;

    void Awake()
    {
        UpdateText();
    }

    public void Eat()
    {
        score += 1;
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = "Score: " + score;
    }

}
