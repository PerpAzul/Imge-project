using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LetterInteract : Interactable
{
    [SerializeField] private TextMeshProUGUI textToUpdate;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject papers;
    public GameObject Text;
    private bool NomorePaper = false;
    [SerializeField] private int index;
    [SerializeField] private GameObject startRounds;

    private void Awake()
    {
        Text.SetActive(false);
    }

    protected override void Interact()
    {
        if (!NomorePaper)
        {
            gameUI.SetActive(false);
            papers.SetActive(true);
            Text.SetActive(true);
            NomorePaper = true;
            Time.timeScale = 0;
        }
        else
        {
            gameUI.SetActive(true);
            papers.SetActive(false);
            Text.SetActive(false);
            NomorePaper = false;
            Time.timeScale = 1;
        }

        if (index == 0)
        {
            startRounds.SetActive(true);
            index++;
        }
    }
}