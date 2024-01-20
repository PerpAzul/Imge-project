using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 60f;
    private float attackTimer;
    private GameObject player;
    private NavMeshAgent agent;
    public Animator zombieAnimator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
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

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        zombieAnimator.SetBool("Dead", true);
        Destroy(gameObject);
    }

    private void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage();
    }
}
