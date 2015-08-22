using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown("f2"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown("f3"))
        {
            paused = !paused;

            if (paused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
