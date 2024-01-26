using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    // List of Player`s powers
    private List<PowerUpInteractable.Power> listPowers;
    
    void Start()
    {
        listPowers = new List<PowerUpInteractable.Power>();
    }
    
    void Update()
    {
        
    }

    public void addPower(PowerUpInteractable.Power power)
    {
        if (!listPowers.Contains(power)) listPowers.Add(power);
    }

    public void removePower(PowerUpInteractable.Power power)
    {
        if (listPowers.Contains(power)) listPowers.Remove(power);
    }

    public bool hasPower(PowerUpInteractable.Power power)
    {
        return listPowers.Contains(power);
    }
    
    
}
