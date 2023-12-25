using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    // Update is called once per frame
    [SerializeField]
    private GameObject Panel;

    private void Awake()
    {
        Panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            isPaused = true;
            Panel.SetActive(true);
            PauseGame();
        }
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
