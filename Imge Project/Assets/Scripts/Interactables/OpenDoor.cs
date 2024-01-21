using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    [SerializeField] private Key key;
    [SerializeField] private Animator animator;
    [SerializeField] private String keyType;

    protected override void Interact()
    {
        if (key.hasKey)
        {
            animator.SetBool("OpenDoor", true);
            GetComponent<BoxCollider>().enabled = false;
            promptMessage = "";
        }
        else
        {
            promptMessage = "I need the " + keyType+ " key";
        }
    }
}
