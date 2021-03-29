using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Pause()
    {
        Screen.fullScreen = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
