using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 30;
    private float attackTimer;
    private GameObject player;
    private NavMeshAgent agent;
    public Animator zombieAnimator;
    private PlayerPoints _playerPoints;
    private RoundManager _roundManager;
    public bool playerInvisible;
    private bool dying;

    //for the audios
    public AudioSource attck_audio;
    public AudioSource roar_audio;
    private float roarTimer;
    public static float volume = 1.0f;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        _playerPoints = FindObjectOfType<PlayerPoints>();
        _roundManager = FindObjectOfType<RoundManager>();
        playerInvisible = false;
    }

    private void Update()
    {
        if (!playerInvisible)
        {
            agent.SetDestination(player.transform.position);
            float targetDistance = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        
            if (targetDistance < 3f)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer > 1f)
                {
                    zombieAnimator.SetTrigger("Attack");
                    Attack();
                    attackTimer = 0;   
                }
            }
            //when zombie is near the player the roar_audio will be played
            if (targetDistance < 10f && !roar_audio.isPlaying)
            {
                roar_audio.volume = volume;
                roar_audio.Play();
                if (roarTimer>30f && !roar_audio.isPlaying)
                {
                    roar_audio.Play();
                }
            }
        }
        else
        {
            agent.SetDestination(gameObject.transform.position);
        }
        //each 15s the zombie will roar
        /*roarTimer += Time.deltaTime;
        if (roarTimer>150f && !roar_audio.isPlaying)
        {
            roar_audio.volume = volume/2;
            roar_audio.Play();
            roarTimer = 0;
        }*/
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        _playerPoints.AddPoints(5);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (dying)
        {
            return;
        }
        
        _playerPoints.AddPoints(100);
        _roundManager.ZombieKilled();

        dying = true;
        zombieAnimator.SetTrigger("Death");
        agent.destination = gameObject.transform.position; // to avoid the enemy getting moved while dying
        agent.speed = 0;
        gameObject.tag = "Untagged";
        StartCoroutine(DestroyOnceAnimationIsOver());
    }

    private IEnumerator DestroyOnceAnimationIsOver()
    {
        yield return new WaitForSeconds(0.5f); //wait a bit so the animation can start to play
        yield return new WaitUntil(() =>
            zombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("dead") ==
            false); // wait until the animation is done playing
        Destroy(gameObject);
    }

    private void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage();
        attck_audio.volume = volume;
        if (!attck_audio.isPlaying)
        {
            attck_audio.Play();
        }
    }

    public void Stop()
    {
        zombieAnimator.SetTrigger("Invisibility");
    }
    
}