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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        agent.SetDestination(player.transform.position);
        float targetDistance = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        
        if (targetDistance < 1f)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > 1f)
            {
                Attack();
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
        Destroy(gameObject);
    }

    private void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage();
    }
}
