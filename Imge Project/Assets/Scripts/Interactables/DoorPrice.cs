using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorPrice : Interactable
{
    [SerializeField] private int price;
    [SerializeField] private Animator animator;
    private RoundManager _roundManager;
    [SerializeField] private bool supermarketDoor;

    private void Start()
    {
        _roundManager = FindObjectOfType<RoundManager>().GetComponent<RoundManager>();
    }

    protected override void Interact()
    {
        PlayerPoints playerPoints = FindObjectOfType<PlayerPoints>();
        int currentPoints = playerPoints.getPoints();
        if (currentPoints >= price)
        {
            playerPoints.DecreasePoints(price);
            animator.SetBool("OpenDoor", true);
            GetComponent<BoxCollider>().enabled = false;
            promptMessage = "";
            if (supermarketDoor)
            {
                SpawnPointChange();
            }
        }
    }

    public void SpawnPointChange()
    {
        
        _roundManager.changeSpawn();
    }
}
