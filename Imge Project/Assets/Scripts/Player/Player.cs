using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEngine.Random;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool running;
    private PlayerPowers _playerPowers;
    public static float volume = 1.0f; //TODO: set volume of Sounds before Sounds.Play() (in Update)

    public float baseSpeed = 10f;
    public float speed;
    public float gravity = -10f;
    public float jumpHeight;
    public int killCount;

    //Dash
    [SerializeField] private Transform orientation;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashUpwardForce;
    [SerializeField] private float cooldownTime = 2;
    private float nextDashTime = 0;
    
    //Dash UI
    public Image dashImage;

    //music
    public AudioSource JumpMusicSource;
    public AudioSource DashMusicSource;
    [SerializeField]
    private AudioSource Run_audioSource;

    public AudioSource ZombieRoarSource;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        _playerPowers = gameObject.GetComponent<PlayerPowers>();
        dashImage.enabled = false;
        killCount = 0;
        StartCoroutine(ZombieSounds());
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
        //_audioSource.volume    = volume;
        //JumpMusicSource.volume = volume;
        //DashMusicSource.volume = volume;
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
        
        if (running && input!=Vector2.zero&&isGrounded && !Run_audioSource.isPlaying)
        {
            Run_audioSource.volume = volume * 0.3f;
            Run_audioSource.Play();
        }
        if(!running)
        {
            Run_audioSource.Stop();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            JumpMusicSource.volume = volume;
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
            DashMusicSource.volume = volume;
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
    IEnumerator ZombieSounds()
    {
        yield return new WaitForSeconds(15.0f);
        while(true)
        {
            if (!ZombieRoarSource.isPlaying)
            {
                ZombieRoarSource.volume = volume / UnityEngine.Random.Range(0.8f, 2.0f);
                ZombieRoarSource.Play();
            }
            yield return new WaitForSeconds(UnityEngine.Random.Range(20.0f, 60.0f));
        }
    }
}