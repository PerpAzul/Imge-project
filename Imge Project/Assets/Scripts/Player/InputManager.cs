using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.PlayerActions playerActions;
    
    private Player player;
    private PlayerLook look;

    void Awake()
    {
        
        playerInput = new PlayerInput();
        playerActions = playerInput.Player;

        player = GetComponent<Player>();
        look = GetComponent<PlayerLook>();

        playerActions.Jump.performed += ctx => player.Jump();
        playerActions.Run.started += ctx => player.StartRun();
        playerActions.Run.canceled += ctx => player.EndRun();
    }

    private void FixedUpdate()
    { 
        player.Move(playerActions.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.Look(playerActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}