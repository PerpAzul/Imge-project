using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI powerUpDescription;
    [SerializeField] private Image descriptionBackground;

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void UpdatePowerUpDescription(string description)
    {
        powerUpDescription.text = description;
        if (description == String.Empty)
        {
            descriptionBackground.enabled = false;
        }
        else
        {
            descriptionBackground.enabled = true;
        }
    }
}