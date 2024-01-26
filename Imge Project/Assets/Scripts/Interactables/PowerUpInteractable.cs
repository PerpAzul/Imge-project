using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpInteractable : Interactable
{
    
    public enum Power {Dash, Invisibility, MoreHealth, MoreDamage}
    
    [SerializeField] private int price;
    [SerializeField] private Power _power;
    private PlayerPowers _playerPowers;
    private PlayerUI _playerUI;
    public string description;


    // Start is called before the first frame update
    void Start()
    {
        _playerPowers = FindObjectOfType<PlayerPowers>().GetComponent<PlayerPowers>();
        string powerName = "";
        description = "";
        switch (_power)
        {
            case Power.Dash:
                powerName = "Blitz Surge";
                description =
                    "Description: Unleash a burst of supernatural speed, enabling you to dash through the undead hordes with unmatched agility.";
                break;
            case Power.Invisibility:
                powerName = "Ghost Veil";
                description =
                    "Description: Cloak yourself in spectral shadows, rendering you invisible to the roaming zombies.";
                break;
            case Power.MoreHealth:
                powerName = "Titan's Vitality";
                description =
                    "Description: Tap into the ancient strength of titans, fortifying your health by to withstand the relentless onslaught.\n(Health increases by 30%)";
                break;
            case Power.MoreDamage:
                powerName = "Fury's Edge";
                description =
                    "Description: Channel the wrath of a warrior, enhancing your weapons to deal devastating damage.\n(Damage increases by 20%)";
                break;
        }
        promptMessage = "Buy " + powerName + " [Cost: " + price + "]";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        PlayerPoints playerPoints = FindObjectOfType<PlayerPoints>();
        int currentPoints = playerPoints.getPoints();
        if (currentPoints >= price)
        {
            playerPoints.DecreasePoints(price);
            _playerPowers.addPower(_power);
        }
    }
}