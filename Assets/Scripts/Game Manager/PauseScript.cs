using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    private GameObject crosshair;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
    }

    void Awake()
    {
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
    }

    public void pauseGame()
    {
        // if game is paused resume game
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenuUI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crosshair.SetActive(false);
        }
    } // pause game

    void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenuUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
    } 

    public void OnResumeGame()
    {
        Resume();

    } // Resume game

    public void OnResetGame()
    {
        GameManager.instance.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    } // Reset game

    public void OnQuitGame()
    {
        Application.Quit();

    } // Quit game

    public void onNewGame()
    {
        GameManager.instance.Reset();
        SceneManager.LoadScene(0);
    } // New game
}
