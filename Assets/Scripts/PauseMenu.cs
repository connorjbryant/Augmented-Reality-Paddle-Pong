using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject LeaderboardUI;

    public GameObject CloseMenuUI;

    GameObject[] pauseObjects;

    public AudioSource audioSource;

    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("Paddle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        audioSource.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        foreach (GameObject g in pauseObjects)
        {
            g.GetComponent<DragObject>().enabled = true;
            //g.SetActive(true);
        }
    }

    public void Resume2()
    {
        audioSource.Play();
        LeaderboardUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        foreach (GameObject g in pauseObjects)
        {
            g.GetComponent<DragObject>().enabled = true;
            //g.SetActive(true);
        }
    }

    public void Pause()
    {
        audioSource.Play();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        foreach (GameObject g in pauseObjects)
        {
            g.GetComponent<DragObject>().enabled = false;
            //g.SetActive(false);
        }
    }

    public void Pause2()
    {
        audioSource.Play();
        LeaderboardUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        foreach (GameObject g in pauseObjects)
        {
            g.GetComponent<DragObject>().enabled = false;
            //g.SetActive(false);
        }
    }

    public void Close()
    {
        CloseMenuUI.SetActive(false);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
