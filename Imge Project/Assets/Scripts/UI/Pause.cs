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
        if (!GamingOptions.gamingOptionIsOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Panel.SetActive(true);
                PauseGame();
            }else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            {
                ContinueGame();
            }
        }
    }
    
    private void PauseGame()
    {
        isPaused = true;
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
