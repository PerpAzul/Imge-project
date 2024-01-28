using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    // Update is called once per frame
    [SerializeField]
    private GameObject Panel;

    private PlayerInput2 _playerInput2;
    private PlayerInput2.PauseMenuActions playerActions;
    
    // Papers Edgecase
    [SerializeField] private GameObject papers;
    
    
    private void Awake()
    {
        Panel.SetActive(false);
        _playerInput2 = new PlayerInput2();
        playerActions = _playerInput2.PauseMenu;
        playerActions.OpenMenu.performed += _ => DeterminePause();
    }

    private void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
        Panel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    public void ContinueGame()
    {
        if (papers.gameObject.activeSelf)
        {
            isPaused = false;
            Panel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void DeterminePause()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else if (!GamingOptions.gamingOptionIsOpen)
        {
            ContinueGame();
        }
    }

}
