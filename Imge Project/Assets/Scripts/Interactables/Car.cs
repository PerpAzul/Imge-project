using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : Interactable
{
    [SerializeField] private Key key;
    [SerializeField] private Key gas;
    [SerializeField] private Key wrench;
    [SerializeField] private Player player;
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private GameObject endUI;
    [SerializeField] private TextMeshProUGUI escape;
    [SerializeField] private TextMeshProUGUI killCount;
    [SerializeField] private TextMeshProUGUI roundCount;

    protected override void Interact()
    {
        if (key.hasKey && gas.hasKey && wrench.hasKey)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            endUI.SetActive(true);
            escape.text = "YOU ESCAPED!";
            roundCount.text = "You Escaped in Round: " + roundManager.currentRound;
            killCount.text = "Zombies Killed: " + player.killCount;
        }
        else
        {
            promptMessage = "The car is not working";
        }
    }
}
