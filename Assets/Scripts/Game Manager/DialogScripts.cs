using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScripts : MonoBehaviour
{
    public GameObject winDialog;
    public GameObject loseDialog;

    private GameObject crosshair;

    void Awake()
    {
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
    }

    public void ShowWin()
    {
        winDialog.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
    }

    public void ShowLose()
    {
        loseDialog.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
    }
}
