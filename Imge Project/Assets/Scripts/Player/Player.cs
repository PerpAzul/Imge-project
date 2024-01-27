using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool running;
    private PlayerPowers _playerPowers;

    public float baseSpeed = 10f;
    public float speed;
    public float gravity = -10f;
    public float jumpHeight;
    
    //Dash
    [SerializeField] private Transform orientation;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashUpwardForce;
    [SerializeField] private float cooldownTime = 2;
    private float nextDashTime = 0;
    
    //Dash UI
    public Image dashImage;
    private float timer;

    //music
    public AudioClip walkMusic;
    public AudioClip runMusic;
    public AudioSource JumpMusicSource;
    public AudioSource DashMusicSource;
    private AudioSource _audioSource;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        _audioSource = audioSources[0];
        _playerPowers = gameObject.GetComponent<PlayerPowers>();
        dashImage.enabled = false;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        // Is in cooldown
        if (dashImage.enabled)
        {
            if (Time.time <= nextDashTime)
            {
                dashImage.fillAmount += 1 / cooldownTime * Time.deltaTime;
                if (dashImage.fillAmount >= 1)
                {
                    dashImage.fillAmount = 1;
                }
            }
            else
            {
                dashImage.fillAmount = 1;
            }
        }
    }

    public void Move(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));

        playerVelocity.y += gravity * Time.deltaTime;
        
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

        _audioSource.clip = running ? runMusic : walkMusic;
        if (input!=Vector2.zero&&isGrounded && !this._audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            JumpMusicSource.Play();
        }
    }

    public void Dash()
    {
        if (_playerPowers.hasPower(PowerUpInteractable.Power.Dash) && Time.time > nextDashTime)
        {
            Vector3 move = orientation.forward * dashForce + orientation.up * dashUpwardForce;
            controller.Move(move);
            nextDashTime = Time.time + cooldownTime;
            dashImage.fillAmount = 0;
            DashMusicSource.Play();
        }
    }

    public void StartRun()
    {
        speed *= 1.5f;
        running = true;
    }

    public void EndRun()
    {
        speed = baseSpeed;
        running = false;
    }
}