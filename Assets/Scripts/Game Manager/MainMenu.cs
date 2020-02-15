using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    string volume_key = "VolumeKey";
    string sfx_key = "SFXKey";
    string level_key = "LevelKey";
    public static int volume_value = 0, toggle_value = 1, level_value = 0;
    public Slider mSlider = null;
    public Toggle mToggle;
    public Toggle mToggleEasy;
    public Toggle mToggleHard;

    void Start()
    {
        Time.timeScale = 1;
        volume_value = PlayerPrefs.GetInt(volume_key);
        toggle_value = PlayerPrefs.GetInt(sfx_key);
        level_value = PlayerPrefs.GetInt(level_key);

        if (mSlider != null)
        {
            mSlider.value = volume_value;
        }
        
        if (toggle_value == 1)
        {
            mToggle.isOn = true;
        }
        else
        {
            mToggle.isOn = false;
        }

        if (level_value == 1)
        {
            mToggleHard.isOn = true;
            mToggleEasy.isOn = false;
        }
        else
        {
            mToggleEasy.isOn = true;
            mToggleHard.isOn = false;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

    public void OnValueChanged(float value)
    {
        PlayerPrefs.SetInt(volume_key, (int)value);
        volume_value = (int)value;
    }

    public void OnToggleValueChanged(bool check)
    {
        if (check)
        {
            PlayerPrefs.SetInt(sfx_key, 1);
            toggle_value = 1;
        }
        else
        {
            PlayerPrefs.SetInt(sfx_key, 0);
            toggle_value = 0;
        }
    }

    public void OnToggleEasyValueChanged(bool check)
    {
        if (check)
        {
            mToggleEasy.isOn = true;
            mToggleHard.isOn = false;
            PlayerPrefs.SetInt(level_key, 0);
            level_value = 0;
        }
        else
        {
            mToggleHard.isOn = true;
            mToggleEasy.isOn = false;
            PlayerPrefs.SetInt(level_key, 1);
            level_value = 1;
        }
    }

    public void OnToggleHardValueChanged(bool check)
    {
        if (check)
        {
            mToggleHard.isOn = true;
            mToggleEasy.isOn = false;
            PlayerPrefs.SetInt(level_key, 1);
        }
        else
        {
            mToggleEasy.isOn = true;
            mToggleHard.isOn = false;
            PlayerPrefs.SetInt(level_key, 0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
