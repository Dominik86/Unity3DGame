using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject winMenu;
    public GameObject winDialog;
    public GameObject loseDialog;
    public GameObject crosshair;
    public GameObject ambientSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        audioSource = ambientSound.GetComponent<AudioSource>();
        audioSource.volume = (float)MainMenu.volume_value / 100f;
    }

    public void Win()
    {
        PauseScript.isPaused = true;
        crosshair.SetActive(false);
        winDialog.SetActive(true);
    }

    public void Lose()
    {
        PauseScript.isPaused = true;
        crosshair.SetActive(false);
        loseDialog.SetActive(true);
    }

    public void Reset()
    {
        PauseScript.isPaused = false;
        crosshair.SetActive(true);
        winDialog.SetActive(false);
        loseDialog.SetActive(false);
        ScoreScript.scoreValue = 0;
    }

    public void Finish()
    {
        PauseScript.isPaused = true;
        crosshair.SetActive(false);
        loseDialog.SetActive(false);
        winDialog.SetActive(false);
        winMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
