using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInteract : Interactable
{
    [SerializeField] private PlayerPoints points;
    [SerializeField] private int amount;
    
    protected override void Interact()
    {
        points.currentPoints += amount;
        Destroy(gameObject);
    }
}
