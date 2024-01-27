using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunWall : Interactable
{
    [SerializeField] private int index;
    [SerializeField] private int priceBuy;
    [SerializeField] private int priceReload;
    [SerializeField] private WeaponSwitching wSwitch;
    [SerializeField] private Shooting shoot;

    private void Update()
    {
        if (index == 1 && wSwitch.hasMachineGun)
        {
            promptMessage = "Buy Assault Rifle Ammo [Cost: 750]";
        }
    }

    protected override void Interact()
    {
        PlayerPoints playerPoints = FindObjectOfType<PlayerPoints>();
        int currentPoints = playerPoints.getPoints();
        
        if (index == 1)
        {
            if (!wSwitch.hasMachineGun && currentPoints >= priceBuy)
            {
                wSwitch.hasMachineGun = true;
                playerPoints.DecreasePoints(priceBuy);
                shoot.maxAmmo = shoot.limitAmmo;
                promptMessage = "Buy Assault Rifle Ammo [Cost: 750]";
                index = 0;
            }
            return;
        }

        if (index == 2)
        {
            if (!wSwitch.hasShotgun && currentPoints >= priceBuy)
            {
                wSwitch.hasShotgun = true;
                playerPoints.DecreasePoints(priceBuy);
                shoot.maxAmmo = shoot.limitAmmo;
                promptMessage = "Buy Shotgun Ammo [Cost: 5000]";
                index = 0;
            }
            return;
        }
        
        if (currentPoints >= priceReload)
        {
            playerPoints.DecreasePoints(priceReload);
            shoot.maxAmmo = shoot.limitAmmo;
        } 
    }
}
