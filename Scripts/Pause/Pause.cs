using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    bool isPaused = false;

    public void palseGame()
    {
        if (isPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;

        }
        else
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
