using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public bool hasKey;

    private void Awake()
    {
        hasKey = false;
    }

    protected override void Interact()
    {
        hasKey = true;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
