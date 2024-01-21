using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Interactable
{
    [SerializeField] private Key key;
    [SerializeField] private Key gas;
    [SerializeField] private Key wrench;

    protected override void Interact()
    {
        if (key.hasKey && gas.hasKey && wrench.hasKey)
        {
            promptMessage = "Level Complete";
        }
        else
        {
            promptMessage = "The car is not working";
        }
    }
}
