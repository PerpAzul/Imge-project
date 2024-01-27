using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrice : Interactable
{
    [SerializeField] private int price;
    [SerializeField] private Animator animator;
    
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
        }
    }
}
