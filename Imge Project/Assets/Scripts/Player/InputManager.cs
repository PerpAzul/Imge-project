using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput2 playerInput;
    public PlayerInput2.PlayerActions playerActions;
    
    private Player player;
    private PlayerLook look;
    private PlayerPowers _powers;

    void Awake()
    {
        playerInput = new PlayerInput2();
        playerActions = playerInput.Player;

        player = GetComponent<Player>();
        look = GetComponent<PlayerLook>();
        _powers = GetComponent<PlayerPowers>();

        playerActions.Jump.performed += ctx => player.Jump();
        playerActions.Run.started += ctx => player.StartRun();
        playerActions.Run.canceled += ctx => player.EndRun();
        playerActions.Dash.performed += ctx => player.Dash();
        playerActions.Invisibility.performed += ctx => StartCoroutine(_powers.becomeInvisible());
    }

    private void FixedUpdate()
    {
        player.Move(playerActions.Move.ReadValue<Vector2>());
    }

    private void Update()
    {
        if ((int) Time.timeScale == 1) look.Look(playerActions.Look.ReadValue<Vector2>());
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