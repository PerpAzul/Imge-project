using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 60;
    private float attackTimer;
    private GameObject player;
    private NavMeshAgent agent;
    public Animator zombieAnimator;
    private PlayerPoints _playerPoints;
    private RoundManager _roundManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        _playerPoints = FindObjectOfType<PlayerPoints>();
        _roundManager = FindObjectOfType<RoundManager>();
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
        float targetDistance = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        
        if (targetDistance < 3f)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > 1f)
            {
                zombieAnimator.SetBool("isAttacking", true);
                Attack();
                zombieAnimator.SetBool("isAttacking", false);
                attackTimer = 0;   
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        zombieAnimator.SetBool("Dead", true);
        _playerPoints.AddPoints(100);
        _roundManager.ZombieKilled();
        Destroy(gameObject);
    }

    private void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage();
    }
}