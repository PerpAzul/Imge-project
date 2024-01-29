using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInteract : Interactable
{
    [SerializeField] private PlayerPoints points;
    [SerializeField] private int amount;
    
    protected override void Interact()
    {
        points.AddPoints(amount);
        Destroy(gameObject);
    }
}
