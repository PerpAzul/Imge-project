using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int currentPoints = 30000;
    [SerializeField] private TextMeshProUGUI pointsUI;

    void Start()
    {
        updateUI();
    }

    public void AddPoints(int pointsToAdd)
    {
        currentPoints += pointsToAdd;
        updateUI();
    }

    public void updateUI()
    {
        pointsUI.text = "Points: " + currentPoints;
    }

    public void DecreasePoints(int pointsToDecrease)
    {
        currentPoints -= pointsToDecrease;
        updateUI();
    }

    public void ResetPoints()
    {
        currentPoints = 0;
        updateUI();
    }

    public int getPoints()
    {
        return currentPoints;
    }
    
}