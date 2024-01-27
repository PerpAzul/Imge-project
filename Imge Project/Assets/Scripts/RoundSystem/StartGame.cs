using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private RoundManager _roundManager;
    
    private void OnTriggerEnter(Collider other)
    {
        _roundManager.StartGame();
        gameObject.SetActive(false);
    }
}
