using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;

    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    //for the music
    public static float volume = 1.0f;
    public AudioSource drink_audio;
    //[SerializeField] private Transform playerPosition;
    private void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                
                // Check if power up interactable
                if (hit.collider.GetComponent<PowerUpInteractable>() != null) playerUI.UpdatePowerUpDescription(hit.collider.GetComponent<PowerUpInteractable>().description);
                if (inputManager.playerActions.Interact.triggered)
                {
                    interactable.BaseInteract();
                    //Debug.Log((interactable.transform.position-playerPosition.position).sqrMagnitude);
                    Debug.Log(interactable.tag);
                    if (interactable.CompareTag("vendingMachines") 
                        /*&&(interactable.transform.position-playerPosition.position).sqrMagnitude < 4.0f*/)
                    {
                        drink_audio.volume = volume;
                        drink_audio.Play();
                    }
                }
            }
        }
        else
        {
            playerUI.UpdateText(string.Empty);
            playerUI.UpdatePowerUpDescription(string.Empty);
        }
    }
}